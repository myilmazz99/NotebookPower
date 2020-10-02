using Entities.Dtos;
using FluentValidation;
using FluentValidation.Validators;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Utilities.FluentValidation
{
    public class EmailValidation : AbstractValidator<EmailListDto>
    {
        public EmailValidation()
        {
            RuleFor(i => i.Email).NotEmpty().WithMessage("Email alanını doldurmak zorunludur.");
            RuleFor(i => i.Email).EmailAddress(EmailValidationMode.Net4xRegex).WithMessage("Girdiğiniz mail adresi geçerli bir mail adresi değildir.");
        }
    }
}
