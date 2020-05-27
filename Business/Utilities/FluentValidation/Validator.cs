using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Utilities.FluentValidation
{
    public static class Validator
    {
        public static void Validate(object entity, IValidator validator)
        {
            var validation = validator.Validate(entity);

            if (!validation.IsValid)
            {
                throw new ValidationException(validation.Errors);
            }
        }
    }
}
