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
    public class EfContactDal : EfEntityRepositoryBase<Contact, TraversalContext>, IContactDal
    {
        public EfContactDal(TraversalContext context) : base(context)
        {
        }
    }
}
