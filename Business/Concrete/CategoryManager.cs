using Business.Abstract;
using Core.Utilities;
using DataAccess.Abstract;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }
         
        public async Task<List<Category>> GetAll()
        {
            return await ExceptionHandler.HandleExceptionWithData<List<Category>>(() => _categoryDal.GetAll());
        }
    }
}
