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
    public class FeatureTwoManager : IFeatureTwoService
    {
        IFeatureTwoDal _featureTwoDal;
        IUnitOfWork _unitOfWork;

        public FeatureTwoManager(IFeatureTwoDal featureTwoDal, IUnitOfWork unitOfWork)
        {
            _featureTwoDal = featureTwoDal;
            _unitOfWork = unitOfWork;
        }

        public IResult Add(FeatureTwo featureTwo)
        {
           _featureTwoDal.Add(featureTwo);
            _unitOfWork.Save();
            return new SuccessResult();
        }

        public IResult Delete(FeatureTwo featureTwo)
        {
           _featureTwoDal.Delete(featureTwo);
            _unitOfWork.Save();
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
            _unitOfWork.Save();
            return new SuccessResult();
        }
    }
}
