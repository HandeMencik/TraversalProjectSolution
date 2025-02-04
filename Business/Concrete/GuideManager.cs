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
    public class GuideManager : IGuideService
    {
        IGuideDal _guideDal;

        public GuideManager(IGuideDal guideDal)
        {
            _guideDal = guideDal;
        }

        public IResult Add(Guide guide)
        {
            _guideDal.Add(guide);
            return new SuccessResult();
        }

        public IResult Delete(Guide guide)
        {
            _guideDal.Delete(guide);
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
            return new SuccessResult();
        }
    }
}
