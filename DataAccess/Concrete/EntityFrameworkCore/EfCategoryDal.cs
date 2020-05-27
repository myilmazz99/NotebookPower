using Core.DataAccess.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.Contexts;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFrameworkCore
{
    public class EfCategoryDal : EfEntityRepository<Category, ShopContext>, ICategoryDal
    {
    }
}
