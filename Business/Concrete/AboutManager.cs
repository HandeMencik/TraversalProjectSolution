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
    public class AboutManager : IAboutService
    {
        IAboutDal _aboutDal;

        public AboutManager(IAboutDal aboutDal)
        {
            _aboutDal = aboutDal;
        }

        public IResult Add(About about)
        {
           _aboutDal.Add(about);
            return new SuccessResult();
        }

        public IResult Delete(About about)
        {
          _aboutDal.Delete(about);
            return new SuccessResult();
        }

        public IDataResult<List<About>> GetAll()
        {
            return new SuccessDataResult<List<About>>(_aboutDal.GetAll());
        }

        public IDataResult<About> GetById(int id)
        {
          return new SuccessDataResult<About>(_aboutDal.Get(x=>x.AboutId == id));
        }

        public IResult Update(About about)
        {
           _aboutDal.Update(about);
            return new SuccessResult();
        }
    }
}
