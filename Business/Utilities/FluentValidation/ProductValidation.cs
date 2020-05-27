using Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Utilities.FluentValidation
{
    public class ProductValidation : AbstractValidator<Product>
    {
        public ProductValidation()
        {
            RuleFor(i => i.OldPrice).NotEmpty().GreaterThanOrEqualTo(1).WithMessage("Fiyat alanına sıfır, negatif veya boş değer girilmemelidir.");
            RuleFor(i => i.NewPrice).NotEmpty().GreaterThanOrEqualTo(1).WithMessage("Fiyat alanına sıfır, negatif veya boş değer girilmemelidir.");

            RuleFor(i => i.ProductName).NotEmpty().WithMessage("Ürün ismi girmek zorunludur.");
            RuleFor(i => i.ProductName).MinimumLength(3).MaximumLength(100).WithMessage("Ürün ismi minimum 3, maximum 100 karakter içermelidir.");

            RuleFor(i=>i.ProductDescription).NotEmpty().WithMessage("Ürün açıklaması girilmelidir.");
            RuleFor(i=>i.ProductDescription).NotEmpty().MinimumLength(10).WithMessage("Ürün açıklaması minimum 10 karakter içermelidir.");

            RuleFor(i => i.Stock).NotEmpty().GreaterThanOrEqualTo(0).WithMessage("Stok alanına negatif veya boş değer girilmemelidir.");
        }
    }
}
