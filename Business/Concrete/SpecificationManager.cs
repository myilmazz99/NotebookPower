﻿using AutoMapper;
using Business.Abstract;
using Core.Utilities;
using DataAccess.Abstract;
using Entities;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class SpecificationManager : ISpecificationService
    {
        private readonly ISpecificationDal _specificationDal;
        private readonly IMapper _mapper;

        public SpecificationManager(ISpecificationDal specificationDal, IMapper mapper)
        {
            _specificationDal = specificationDal;
            _mapper = mapper;
        }

        public async Task<IEnumerable<int>> Create(List<SpecificationDto> entities)
        {
            return await _specificationDal.AddOrUpdateMultiple(_mapper.Map<List<Specification>>(entities));
        }

        public async Task<List<SpecificationDto>> GetAll()
        {
            return _mapper.Map<List<SpecificationDto>>(await _specificationDal.GetAll());
        }

        public async Task RemoveSpecification(int productId, int specId)
        {
            await _specificationDal.RemoveSpecification(productId, specId);
        }
    }
}
