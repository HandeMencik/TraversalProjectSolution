using Core.Utilities.Results;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ISubAboutService
    {
        IResult Add(SubAbout subAbout);
        IResult Delete(SubAbout subAbout);
        IResult Update(SubAbout subAbout);
        IDataResult<List<SubAbout>> GetAll();
        IDataResult<SubAbout> GetById(int id);
    }
}
