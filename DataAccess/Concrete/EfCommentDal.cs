using Core.DataAccess.EntityFramework;
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

            return _context.Comments
                .Include(x => x.AppUser)
                .Include(x => x.Destination)
                .Where(filter)
                .ToList();

        }

      
    }
}
