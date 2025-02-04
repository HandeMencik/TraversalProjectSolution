using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace TraversalReservationProject.ViewComponents.Default
{
    public class _TestimonialDefaultPartial:ViewComponent
    {
        private readonly ITestimonialService _testimonialService;

        public _TestimonialDefaultPartial(ITestimonialService testimonialService)
        {
            _testimonialService = testimonialService;
        }

        public IViewComponentResult Invoke()
        {
            var results = _testimonialService.GetAll();
            if (results.Success)
            {
                return View(results.Data);
            }
            return View(); 
        }
    }
}
