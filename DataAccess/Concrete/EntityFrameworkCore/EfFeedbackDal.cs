﻿using Core.DataAccess.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.Contexts;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFrameworkCore
{
    public class EfFeedbackDal : EfEntityRepository<Feedback, ShopContext>, IFeedbackDal
    {
    }
}
