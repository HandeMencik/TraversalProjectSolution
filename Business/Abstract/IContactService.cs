using Core.Utilities.Results;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IContactService
    {
        IResult Add(Contact contact);
        IResult Delete(Contact contact);
        IResult Update(Contact contact);
        IDataResult<List<Contact>> GetAll();
        IDataResult<Contact> GetById(int id);
    }
}
