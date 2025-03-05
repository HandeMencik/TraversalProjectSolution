using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Context;
using DataAccess.UnitOfWork;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class EfAccountDal : EfEntityRepositoryBase<Account, TraversalContext>, IAccountDal
    {

        public EfAccountDal(TraversalContext context, IUnitOfWork unitOfWork) : base(context)
        {

        }

        public void MultiUpdate(List<Account> accounts)
        {
            _context.UpdateRange(accounts);
            _context.SaveChanges();
        }
    }
}
