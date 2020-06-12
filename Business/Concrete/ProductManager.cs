using AutoMapper;
using Business.Abstract;
using Business.Utilities.FluentValidation;
using Core.Utilities;
using DataAccess.Abstract;
using Entities;
using Entities.Dtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        private IProductDal _productDal;
        private IMapper _mapper;

        public ProductManager(IProductDal productDal, IMapper mapper)
        {
            _productDal = productDal;
            _mapper = mapper;
        }

        public async Task<int> Add(ProductDto entity, IEnumerable<int> specIds)
        {
            Validator.Validate(entity, new ProductValidation());
            return await ExceptionHandler.HandleExceptionWithData<int>(() =>
            {
                return _productDal.Create(_mapper.Map<Product>(entity), specIds);
            });
        }

        public async Task AddImages(List<ProductImageDto> images)
        {
            await ExceptionHandler.HandleException(() => 
            { 
                return _productDal.AddImages(_mapper.Map<List<ProductImage>>(images)); 
            });
        }

        public async Task<ProductDto> GetById(int id)
        {
            return await ExceptionHandler.HandleExceptionWithData<ProductDto>(async () => _mapper.Map<ProductDto>(await _productDal.GetById(id)));
        }
    }
}
