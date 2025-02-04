using Core.Utilities.Results;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IGuideService
    {
        IResult Add(Guide guide);
        IResult Delete(Guide guide);
        IResult Update(Guide guide);
        IDataResult<List<Guide>> GetAll();
        IDataResult<Guide> GetById(int id);
    }
}
