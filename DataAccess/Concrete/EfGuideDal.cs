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
    public class EfGuideDal : EfEntityRepositoryBase<Guide, TraversalContext>, IGuideDal
    {
        public EfGuideDal(TraversalContext context) : base(context)
        {
        }

        public void ChangeToFalseByGuide(int id)
        {
            throw new NotImplementedException();
        }

        public void ChangeToTrueByGuide(int id)
        {
            throw new NotImplementedException();
        }
    }
}
