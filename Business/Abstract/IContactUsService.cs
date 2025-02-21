using Core.Utilities.Results;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IContactUsService
    {
        IResult Add(ContactUs contactUs);
        IResult Delete(ContactUs contactUs);
        IResult Update(ContactUs contactUs);
        IDataResult<List<ContactUs>> GetAll();
        IDataResult<ContactUs> GetById(int id);
        IDataResult<List<ContactUs>> GetListByTrue();
        IDataResult<List<ContactUs>> GetListByFalse();   
        void ContactUsStatusChanceToFalse(int id);
    }
}
