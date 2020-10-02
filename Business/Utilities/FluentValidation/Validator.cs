using FluentValidation;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
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
                var deneme = validation.Errors;
                throw new ValidationException(JsonConvert.SerializeObject(deneme.Select(i => new { i.PropertyName, i.ErrorMessage})));
            }
        }
    }
}
