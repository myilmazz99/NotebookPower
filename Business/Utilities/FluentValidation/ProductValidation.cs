using Entities;
using Entities.Dtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Utilities.FluentValidation
{
    public class ProductValidation : AbstractValidator<ProductDto>
    {
        public ProductValidation()
        {
            RuleFor(i => i.OldPrice).GreaterThanOrEqualTo(1).WithMessage("Fiyat alanına sıfır veya negatif değer girilmemelidir.");
            RuleFor(i => i.OldPrice).NotEmpty().WithMessage("Fiyat alanı boş bırakılmamalıdır.");

            RuleFor(i => i.NewPrice).GreaterThanOrEqualTo(1).WithMessage("İndirimli fiyat alanına sıfır veya negatif değer girilmemelidir.");

            RuleFor(i => i.ProductName).NotEmpty().WithMessage("Ürün ismi alanı boş bırakılmamalıdır.");
            RuleFor(i => i.ProductName).MaximumLength(100).WithMessage("Ürün ismi maximum 100 karakter içermelidir.");
            RuleFor(i => i.ProductName).MinimumLength(3).WithMessage("Ürün ismi minimum 3 karakter içermelidir.");

            RuleFor(i=>i.ProductDescription).NotEmpty().WithMessage("Ürün açıklaması alanı boş bırakılmamalıdır.");
            RuleFor(i=>i.ProductDescription).MinimumLength(10).WithMessage("Ürün açıklaması minimum 10 karakter içermelidir.");

            RuleFor(i => i.Stock).GreaterThanOrEqualTo(0).WithMessage("Stok alanına negatif değer girilmemelidir.");
            RuleFor(i => i.Stock).NotEmpty().WithMessage("Stok alanı boş bırakılmamalıdır.");
        }
    }
}
