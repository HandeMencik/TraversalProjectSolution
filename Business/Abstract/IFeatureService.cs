using Core.Utilities.Results;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IFeatureService
    {
        IResult Add(Feature feature);
        IResult Delete(Feature feature);
        IResult Update(Feature feature);
        IDataResult<List<Feature>> GetAll();
        IDataResult<Feature> GetById(int id);
    }
}
