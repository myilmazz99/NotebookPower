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
using Business.Utilities.Aspects;
using Autofac.Extras.DynamicProxy;
using System.Linq;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        private readonly IProductDal _productDal;
        private readonly IMapper _mapper;

        public ProductManager(IProductDal productDal, IMapper mapper)
        {
            _productDal = productDal;
            _mapper = mapper;
        }

        public async Task<int> Add(ProductDto entity)
        {
            Validator.Validate(entity, new ProductValidation());
            Product product = _mapper.Map<Product>(entity);
            product.ProductSpecifications = entity.Specifications.Select(i=> new ProductSpecification{ Specification = new Specification{SpecificationName = i.SpecificationName, SpecificationValue = i.SpecificationValue} }).ToList();
            
            return await _productDal.Create(product);
        }

        public async Task AddImages(List<ProductImageDto> images)
        {
            await _productDal.AddImages(_mapper.Map<List<ProductImage>>(images));
        }

        public async Task<List<ProductDto>> GetAllWithIncludes()
        {
            return _mapper.Map<List<ProductDto>>(await _productDal.GetAllWithIncludes());
        }

        public async Task<ProductDto> GetById(int id)
        {
            return _mapper.Map<ProductDto>(await _productDal.GetById(id));
        }

        public async Task<List<ProductDto>> GetBestSeller()
        {
            return _mapper.Map<List<ProductDto>>(await _productDal.GetBestSeller());
        }

        public async Task<List<ProductDto>> GetDailyDeals()
        {
            return _mapper.Map<List<ProductDto>>(await _productDal.GetDailyDeals());
        }

        public async Task<List<ProductDto>> GetSimiliar(int categoryId)
        {
            return _mapper.Map<List<ProductDto>>(await _productDal.GetSimiliar(categoryId));
        }

        public async Task<ProductDto> Update(ProductDto dto, IEnumerable<int> specIds)
        {
            Validator.Validate(dto, new ProductValidation());
            await _productDal.Update(_mapper.Map<Product>(dto), specIds);
            return dto;
        }

        public async Task Delete(int id)
        {
            await _productDal.DeleteAsync(id);
        }
    }
}
