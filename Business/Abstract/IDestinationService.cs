using Core.Utilities.Results;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IDestinationService
    {
        IResult Add(Destination destination);
        IResult Delete(Destination destination);
        IResult Update(Destination destination);
        IDataResult<List<Destination>> GetAll();
        IDataResult<Destination> GetById(int id);
    }
}
