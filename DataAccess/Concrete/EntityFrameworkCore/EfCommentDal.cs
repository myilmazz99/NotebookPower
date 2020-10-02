using Core.DataAccess.Concrete;
using DataAccess.Abstract;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFrameworkCore
{
    public class EfCommentDal<TContext> : EfEntityRepository<Comment, TContext>, ICommentDal
        where TContext : DbContext, new()
    {
    }
}
