using Business.Abstract;
using Business.Utilities.FluentValidation;
using Core.Utilities;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class AccountManager : IAccountService
    {
        private IAccountDal _accountDal;

        public AccountManager(IAccountDal accountDal)
        {
            _accountDal = accountDal;
        }

        public IResult Add(UserDto user)
        {
            var result = ExceptionHandler.HandleException( async () =>
            {
                await _accountDal.Add(user);
                Validator.Validate(user, new UserValidation());
            });

            if (result.Success)
            {
                result.Message = "Kullanıcı başarıyla oluşturuldu.";
                return result;
            }

            return new ErrorResult();
        }
    }
}
