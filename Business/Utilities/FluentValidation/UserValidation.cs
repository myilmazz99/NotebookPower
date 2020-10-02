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
        private const string lowerCaseLetters = "abcçdefgğhıijklmnoöpqrstuüvwxyz";
        private const string upperCaseLetters = "ABCÇDEFGĞHIİJKLMNOÖPQRSTUÜVWXYZ";
        private const string numbers = "0123456789";

        public UserValidation()
        {
            RuleFor(i => i.Email).EmailAddress(EmailValidationMode.Net4xRegex).WithMessage("Girdiğiniz email adresi geçersizdir.");
            RuleFor(i => i.FullName).NotEmpty().WithMessage("Ad ve soyad alanı boş bırakılamaz.");

            RuleFor(i => i.Password).NotEmpty().WithMessage("Şifre alanı boş bırakılamaz.");
            RuleFor(i => i.Password).MinimumLength(6).WithMessage("Şifre alanı en az 6 karakter içermelidir.");
            RuleFor(i => i.Password).Custom(CheckLowerCaseLetter);
            RuleFor(i => i.Password).Custom(CheckUpperCaseLetter);
            RuleFor(i => i.Password).Custom(CheckDigit);


            RuleFor(i => i.Password).Equal(i => i.RePassword).WithMessage("Girdiğiniz şifreler uyuşmuyor.");
        }

        private void CheckLowerCaseLetter(string str, CustomContext context)
        {
            var charArray = lowerCaseLetters.ToCharArray();
            foreach (var c in charArray)
            {
                if (str.Contains(c)) break;
                if (c == charArray[charArray.Length - 1] && !str.Contains(c))
                    context.AddFailure("Şifre alanı en az 1 küçük karakter içermelidir.");
            }
        }

        private void CheckUpperCaseLetter(string str, CustomContext context)
        {
            var charArray = upperCaseLetters.ToCharArray();
            foreach (var c in charArray)
            {
                if (str.Contains(c)) break;
                if (c == charArray[charArray.Length - 1] && !str.Contains(c))
                    context.AddFailure("Şifre alanı en az 1 büyük karakter içermelidir.");
            }
        }

        private void CheckDigit(string str, CustomContext context)
        {
            var charArray = numbers.ToCharArray();
            foreach (var c in charArray)
            {
                if (str.Contains(c)) break;
                if (c == charArray[charArray.Length - 1] && !str.Contains(c))
                    context.AddFailure("Şifre alanı en az 1 sayısal karakter içermelidir.");
            }
        }
    }
}
