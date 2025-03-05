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
    public class TestimonialManager : ITestimonialService
    {
        ITestimonialDal _testimonialDal;
        IUnitOfWork _unitOfWork;

        public TestimonialManager(ITestimonialDal testimonialDal, IUnitOfWork unitOfWork)
        {
            _testimonialDal = testimonialDal;
            _unitOfWork = unitOfWork;
        }

        public IResult Add(Testimonial testimonial)
        {
            _testimonialDal.Add(testimonial);
            _unitOfWork.Save();
            return new SuccessResult();
        }

        public IResult Delete(Testimonial testimonial)
        {
            _testimonialDal.Delete(testimonial);
            _unitOfWork.Save();
            return new SuccessResult();
        }

        public IDataResult<List<Testimonial>> GetAll()
        {
            return new SuccessDataResult<List<Testimonial>>(_testimonialDal.GetAll());
        }

        public IDataResult<Testimonial> GetById(int id)
        {
          return new SuccessDataResult<Testimonial>(_testimonialDal.Get(x=>x.TestimonialId == id));
        }

        public IResult Update(Testimonial testimonial)
        {
            _testimonialDal.Update(testimonial);
            _unitOfWork.Save();
            return new SuccessResult();
        }
    }
}
