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
    public class NewsLEtterManager : INewsLetterService
    {
        INewsLetterDal _newsLetterDal;
        IUnitOfWork _unitOfWork;

        public NewsLEtterManager(INewsLetterDal newsLetterDal, IUnitOfWork unitOfWork)
        {
            _newsLetterDal = newsLetterDal;
            _unitOfWork = unitOfWork;
        }

        public IResult Add(NewsLetter newsLetter)
        {
            _newsLetterDal.Add(newsLetter);
            _unitOfWork.Save();
            return new SuccessResult();
        }

        public IResult Delete(NewsLetter newsLetter)
        {
            _newsLetterDal.Delete(newsLetter);
            _unitOfWork.Save();
            return new SuccessResult();
        }

        public IDataResult<List<NewsLetter>> GetAll()
        {
          return new SuccessDataResult<List<NewsLetter>>(_newsLetterDal.GetAll());
        }

        public IDataResult<NewsLetter> GetById(int id)
        {
          return new SuccessDataResult<NewsLetter>(_newsLetterDal.Get(x=>x.NewsLetterId == id));
        }

        public IResult Update(NewsLetter newsLetter)
        {
            _newsLetterDal.Update(newsLetter);
            _unitOfWork.Save();
            return new SuccessResult();
        }
    }
}
