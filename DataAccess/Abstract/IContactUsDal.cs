using Core.DataAccess.EntityFramework;
using Core.Utilities.Results;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IContactUsDal : IEntityRepository<ContactUs>
    {
        IDataResult<List<ContactUs>> GetListByTrue();
        IDataResult<List<ContactUs> >GetListByFalse();
        void ContactUsStatusChanceToFalse(int id);
    }
}
