using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.UnitOfWork;
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
        IUnitOfWork _unitOfWork;

        public AboutManager(IAboutDal aboutDal, IUnitOfWork unitOfWork)
        {
            _aboutDal = aboutDal;
            _unitOfWork = unitOfWork;
        }

        public IResult Add(About about)
        {
            _aboutDal.Add(about);
            _unitOfWork.Save();
            return new SuccessResult();
        }

        public IResult Delete(About about)
        {
            _aboutDal.Delete(about);
            _unitOfWork.Save();
            return new SuccessResult();
        }

        public IDataResult<List<About>> GetAll()
        {
            return new SuccessDataResult<List<About>>(_aboutDal.GetAll());
        }

        public IDataResult<About> GetById(int id)
        {
            return new SuccessDataResult<About>(_aboutDal.Get(x => x.AboutId == id));
        }

        public IResult Update(About about)
        {
            _aboutDal.Update(about);
            _unitOfWork.Save();
            return new SuccessResult();
        }
    }
}
