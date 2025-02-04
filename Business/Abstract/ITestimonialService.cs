using Core.Utilities.Results;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ITestimonialService
    {
        IResult Add(Testimonial testimonial);
        IResult Delete(Testimonial testimonial);
        IResult Update(Testimonial testimonial);
        IDataResult<List<Testimonial>> GetAll();
        IDataResult<Testimonial> GetById(int id);
    }
}
