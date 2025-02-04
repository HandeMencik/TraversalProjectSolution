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
    public class NewsLEtterManager : INewsLetterService
    {
        INewsLetterDal _newsLetterDal;

        public NewsLEtterManager(INewsLetterDal newsLetterDal)
        {
            _newsLetterDal = newsLetterDal;
        }

        public IResult Add(NewsLetter newsLetter)
        {
            _newsLetterDal.Add(newsLetter);
            return new SuccessResult();
        }

        public IResult Delete(NewsLetter newsLetter)
        {
            _newsLetterDal.Delete(newsLetter);
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
            return new SuccessResult();
        }
    }
}
