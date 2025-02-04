using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ContactManager:IContactService
    {
        IContactDal _contactDal;

        public ContactManager(IContactDal contactDal)
        {
            _contactDal = contactDal;
        }

        public IResult Add(Contact contact)
        {
           _contactDal.Add(contact);
            return new SuccessResult();
        }

        public IResult Delete(Contact contact)
        {
          _contactDal.Delete(contact);
            return new SuccessResult();
        }

        public IDataResult<List<Contact>> GetAll()
        {
        return new SuccessDataResult<List<Contact>>(_contactDal.GetAll());
        }

        public IDataResult<Contact> GetById(int id)
        {
            return new SuccessDataResult<Contact>(_contactDal.Get(x=>x.ContactId == id));
        }

        public IResult Update(Contact contact)
        {
            _contactDal.Update(contact);
            return new SuccessResult();
        }
    }
}
