using AutoMapper;
using Business.Abstract;
using DataAccess.Abstract;
using Entities;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CartManager : ICartService
    {
        private readonly ICartDal _cartDal;
        private readonly IMapper _mapper;

        public CartManager(ICartDal cartDal, IMapper mapper)
        {
            _cartDal = cartDal;
            _mapper = mapper;
        }

        public async Task<CartDto> Create(string userId)
        {
            await _cartDal.AddAsync(new Cart() { UserId= userId });
            return _mapper.Map<CartDto>(await _cartDal.GetByUserId(userId));
        }

        public async Task RemoveFromCart(RemoveFromCartDto dto)
        {
            await _cartDal.RemoveFromCart(dto);
        }

        public async Task<CartDto> Get(string userId)
        {
            return _mapper.Map<CartDto>(await _cartDal.GetByUserId(userId));
        }

        public async Task<CartItemDto> Update(AddToCartDto dto)
        {
            return _mapper.Map<CartItemDto>(await _cartDal.Update(dto));
        }
    }
}
