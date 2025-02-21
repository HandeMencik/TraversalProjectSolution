using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ContactUsManager : IContactUsService
    {
        IContactUsDal _contactUsDal;

        public ContactUsManager(IContactUsDal contactUsDal)
        {
            _contactUsDal = contactUsDal;
        }

        public IResult Add(ContactUs contactUs)
        {
          _contactUsDal.Add(contactUs);
            return new SuccessResult();
        }

        public void ContactUsStatusChanceToFalse(int id)
        {
            throw new NotImplementedException();
        }

        public IResult Delete(ContactUs contactUs)
        {
            _contactUsDal.Delete(contactUs);
            return new SuccessResult();
        }

        public IDataResult<List<ContactUs>> GetAll()
        {
            return new SuccessDataResult<List<ContactUs>>(_contactUsDal.GetAll());
        }

        public IDataResult<ContactUs> GetById(int id)
        {
            return new SuccessDataResult<ContactUs>(_contactUsDal.Get(x=>x.ContactUsId==id));
        }

        public IDataResult<List<ContactUs>> GetListByFalse()
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<ContactUs>> GetListByTrue()
        {
            var results = _contactUsDal.GetListByTrue();
            return new SuccessDataResult<List<ContactUs>>(results.Data);
        }

        public IResult Update(ContactUs contactUs)
        {
            _contactUsDal.Update(contactUs);
            return new SuccessResult();
        }
    }
}
