using Core.Utilities.Results;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IFeatureTwoService
    {
        IResult Add(FeatureTwo featureTwo);
        IResult Delete(FeatureTwo featureTwo);
        IResult Update(FeatureTwo featureTwo);
        IDataResult<List<FeatureTwo>> GetAll();
        IDataResult<FeatureTwo> GetById(int id);
    }
}
