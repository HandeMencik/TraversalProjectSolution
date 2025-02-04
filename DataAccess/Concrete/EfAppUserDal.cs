using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Context;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class EfAppUserDal : EfEntityRepositoryBase<AppUser, TraversalContext>, IAppUserDal
    {
        public EfAppUserDal(TraversalContext context) : base(context)
        {
        }
    }
}
