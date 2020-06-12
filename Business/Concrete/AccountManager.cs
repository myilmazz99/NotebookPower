using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Business.Abstract;
using Business.Utilities.FluentValidation;
using Core.Entities.Concrete;
using Core.Security;
using Core.Utilities;
using Entities.Dtos;
using Microsoft.AspNetCore.Identity;

namespace Business.Concrete
{
    public class AccountManager : IAccountService
    {
        private readonly IMapper _mapper;
        private readonly JwtHelper _jwtHelper;
        private readonly UserManager<ApplicationUser> _userManager;

        public AccountManager(IMapper mapper, JwtHelper jwtHelper, UserManager<ApplicationUser> userManager)
        {
            _mapper = mapper;
            _jwtHelper = jwtHelper;
            _userManager = userManager;
        }

        public async Task<AccessToken> Login(UserDto user)
        {
            Validator.Validate(user, new UserValidation());
            var IsUserValid = await _userManager.FindByEmailAsync(user.Email);
            if (IsUserValid == null) throw new AuthException("Kullanıcı bulunamadı.");
            return _jwtHelper.CreateToken(_mapper.Map<ApplicationUser>(IsUserValid));
        }

        public async Task Register(UserDto user)
        {
            Validator.Validate(user, new UserValidation());
            await _userManager.CreateAsync(_mapper.Map<ApplicationUser>(user));
            //if(result.Succeeded)
            //Email conf stuff.
        }

        public async Task<UserDto> GetUserCredentials(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            return _mapper.Map<UserDto>(user);
        }

        //public async Task<UserDto> GetUserFavorites(string userId)
        //{
        //    var user = await _userManager.FindByIdAsync(userId);
        //    return _mapper.Map<UserDto>(user);
        //}

        //public async Task<UserDto> GetPastOrders(string userId)
        //{
        //    var user = await _userManager.FindByIdAsync(userId);
        //    return _mapper.Map<UserDto>(user);
        //}
    }
}
