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
    public class GuideManager : IGuideService
    {
        IGuideDal _guideDal;
        IUnitOfWork _unitOfWork;

        public GuideManager(IGuideDal guideDal, IUnitOfWork unitOfWork)
        {
            _guideDal = guideDal;
            _unitOfWork = unitOfWork;
        }

        public IResult Add(Guide guide)
        {
            _guideDal.Add(guide);
            _unitOfWork.Save();
            return new SuccessResult();
        }

        public IResult Delete(Guide guide)
        {
            _guideDal.Delete(guide);
            _unitOfWork.Save();
            return new SuccessResult();
        }

        public IDataResult<List<Guide>> GetAll()
        {
         return new SuccessDataResult<List<Guide>>(_guideDal.GetAll());
        }

        public IDataResult<Guide> GetById(int id)
        {
         return new SuccessDataResult<Guide>(_guideDal.Get(x=>x.GuideId == id));
        }

        public IResult Update(Guide guide)
        {
           _guideDal.Update(guide);
            _unitOfWork.Save();
            return new SuccessResult();
        }
    }
}
