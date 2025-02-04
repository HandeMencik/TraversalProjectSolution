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
    public class FeatureManager : IFeatureService
    {
        IFeatureDal _featureDal;

        public FeatureManager(IFeatureDal featureDal)
        {
            _featureDal = featureDal;
        }

        public IResult Add(Feature feature)
        {
          _featureDal.Add(feature);
            return new SuccessResult();
        }

        public IResult Delete(Feature feature)
        {
          _featureDal.Delete(feature);
            return new SuccessResult();
        }

        public IDataResult<List<Feature>> GetAll()
        {
          return new SuccessDataResult<List<Feature>>(_featureDal.GetAll());
        }

        public IDataResult<Feature> GetById(int id)
        {
           return new SuccessDataResult<Feature>(_featureDal.Get(x=>x.FeatureId == id));
        }

        public IResult Update(Feature feature)
        {
          _featureDal.Update(feature);
            return new SuccessResult();
        }
    }
}
