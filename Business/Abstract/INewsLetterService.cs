using Core.Utilities.Results;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface INewsLetterService
    {
        IResult Add(NewsLetter newsLetter);
        IResult Delete(NewsLetter newsLetter);
        IResult Update(NewsLetter newsLetter);
        IDataResult<List<NewsLetter>> GetAll();
        IDataResult<NewsLetter> GetById(int id);
    }
}
