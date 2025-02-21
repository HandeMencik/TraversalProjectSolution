using Core.DataAccess.EntityFramework;
using Core.Utilities.Results;
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
    public class EfContactUsDal : EfEntityRepositoryBase<ContactUs, TraversalContext>, IContactUsDal
    {
        private readonly TraversalContext _context;
        public EfContactUsDal(TraversalContext context) : base(context)
        {
            _context = context;
        }

        public void ContactUsStatusChanceToFalse(int id)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<ContactUs>> GetListByFalse()
        {
           var results=_context.ContactUses.Where(x=>x.MessageStatus==false).ToList();
            return new SuccessDataResult<List<ContactUs>>(results);
       
           
        }

        public IDataResult<List<ContactUs>> GetListByTrue()
        {
            var results = _context.ContactUses.Where(x => x.MessageStatus == true).ToList();
            return new SuccessDataResult<List<ContactUs>>(results);
        }
    }
}
