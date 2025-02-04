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
    public class FeatureTwoManager : IFeatureTwoService
    {
        IFeatureTwoDal _featureTwoDal;

        public FeatureTwoManager(IFeatureTwoDal featureTwoDal)
        {
            _featureTwoDal = featureTwoDal;
        }

        public IResult Add(FeatureTwo featureTwo)
        {
           _featureTwoDal.Add(featureTwo);
            return new SuccessResult();
        }

        public IResult Delete(FeatureTwo featureTwo)
        {
           _featureTwoDal.Delete(featureTwo);
            return new SuccessResult();
        }

        public IDataResult<List<FeatureTwo>> GetAll()
        {
           return new SuccessDataResult<List<FeatureTwo>>(_featureTwoDal.GetAll());
        }

        public IDataResult<FeatureTwo> GetById(int id)
        {
          return new SuccessDataResult<FeatureTwo>(_featureTwoDal.Get(x=>x.FeatureTwoId == id));
        }

        public IResult Update(FeatureTwo featureTwo)
        {
           _featureTwoDal.Update(featureTwo);
            return new SuccessResult();
        }
    }
}
