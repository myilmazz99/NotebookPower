using Entities.Dtos;
using FluentValidation;
using FluentValidation.Validators;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Utilities.FluentValidation
{
    public class UserValidation : AbstractValidator<UserDto>
    {
        public UserValidation()
        {
            RuleFor(i => i.Email).EmailAddress(EmailValidationMode.Net4xRegex).WithMessage("Lütfen geçerli bir email adresi giriniz.");
        }
    }
}
