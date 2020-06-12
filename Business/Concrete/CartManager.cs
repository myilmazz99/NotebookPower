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

        public async Task Create(int userId)
        {
            await _cartDal.AddAsync(new Cart() { UserId= userId });
        }

        public async Task<CartDto> Get(int id)
        {
            return _mapper.Map<CartDto>(await _cartDal.GetById(id));
        }

        public async Task Update(CartDto entity)
        {
            await _cartDal.UpdateAsync(_mapper.Map<Cart>(entity));
        }
    }
}
