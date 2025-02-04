﻿using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Context;
using Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class EfCommentDal : EfEntityRepositoryBase<Comment, TraversalContext>, ICommentDal
    {
        public EfCommentDal(TraversalContext context) : base(context)
        {
        }

        public List<Comment> GetDestinationById(Expression<Func<Comment, bool>> filter)
        {
            using (var context = new TraversalContext())
            {
                return context.Comments
                    .Include(x => x.Destination)
                    .Where(filter) // Filtreyi burada kullanıyoruz
                    .ToList();
            }
        }
    }
}
