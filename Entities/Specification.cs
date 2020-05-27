using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class Specification : IEntity
    {
        public int Id { get; set; }
        public string SpecificationName { get; set; }
        public string SpecificationValue { get; set; }
        public List<ProductSpecification> ProductSpecifications { get; set; }
    }
}
