﻿using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ISpecificationService
    {
        Task<IEnumerable<int>> Create(List<SpecificationDto> entities);
        Task<List<SpecificationDto>> GetAll();
        Task RemoveSpecification(int productId, int specId);
    }
}
