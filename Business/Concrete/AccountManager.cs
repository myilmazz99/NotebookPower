using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Business.Abstract;
using Business.Services;
using Business.Utilities.FluentValidation;
using Core.Entities.Concrete;
using Core.Security;
using Core.Utilities;
using DataAccess.Abstract;
using Entities;
using Entities.Dtos;
using Microsoft.AspNetCore.Identity;

namespace Business.Concrete
{
    public class AccountManager : IAccountService
    {
        private readonly IMapper _mapper;
        private readonly JwtHelper _jwtHelper;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IFavoriteDal _favoriteDal;
        private readonly IEmailSender _emailSender;

        public AccountManager(IMapper mapper, JwtHelper jwtHelper, UserManager<ApplicationUser> userManager, IFavoriteDal favoriteDal, IEmailSender emailSender)
        {
            _mapper = mapper;
            _jwtHelper = jwtHelper;
            _userManager = userManager;
            _favoriteDal = favoriteDal;
            _emailSender = emailSender;
        }

        public async Task<AccessToken> Login(LoginDto user)
        {
            var IsUserValid = await _userManager.FindByEmailAsync(user.Email);
            if (IsUserValid == null) throw new AuthException("Kullanıcı bulunamadı.");
            if (!IsUserValid.EmailConfirmed) throw new AuthException("Lütfen mailinizi onaylayınız.");

            if (!await _userManager.CheckPasswordAsync(IsUserValid, user.Password))
                throw new AuthException("Emailiniz veya şifreniz yanlış. Lütfen tekrar deneyiniz.");

            return _jwtHelper.CreateToken(_mapper.Map<ApplicationUser>(IsUserValid));
        }

        public async Task<AccessToken> Register(UserDto user)
        {
            Validator.Validate(user, new UserValidation());
            var map = _mapper.Map<ApplicationUser>(user);
            map.UserName = map.Email;
            map.RoleName = "user";
            var result = await _userManager.CreateAsync(map, user.Password);
            if (result.Succeeded)
            {
                var newUser = await _userManager.FindByEmailAsync(user.Email);
                return _jwtHelper.CreateToken(_mapper.Map<ApplicationUser>(newUser));
            }
            else
            {
                throw new AuthException(result.Errors.Select(i => i.Description));
            }
        }

        public async Task<UserDto> GetUserCredentials(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null) throw new AuthException("Kullanıcı bulunamadı.");
            return _mapper.Map<UserDto>(user);
        }

        public async Task<List<FavoriteDto>> GetFavoriteProducts(string userId)
        {
            return _mapper.Map<List<FavoriteDto>>(await _favoriteDal.GetAllWithProducts(i => i.UserId == userId));
        }

        public async Task ConfirmEmail(string id, string token)
        {
            await _userManager.ConfirmEmailAsync(await _userManager.FindByIdAsync(id), token);
        }

        public async Task<FavoriteDto> AddToFavorite(string userId, int productId)
        {
            return _mapper.Map<FavoriteDto>(await _favoriteDal.AddAsync(userId, productId));
        }

        public async Task RemoveFromFavorite(string userId, int productId)
        {
            var fav = await _favoriteDal.Get(i => i.ProductId == productId && i.UserId == userId);
            await _favoriteDal.DeleteAsync(fav.Id);
        }
    }
}
