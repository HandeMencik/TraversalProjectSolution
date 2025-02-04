using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace TraversalReservationProject.ViewComponents.Default
{
    public class _SubAboutDefaultPartial : ViewComponent
    {
        private readonly ISubAboutService _subAboutService;

        public _SubAboutDefaultPartial(ISubAboutService subAboutService)
        {
            _subAboutService = subAboutService;
        }

        public IViewComponentResult Invoke()
        {
            var results = _subAboutService.GetAll();
            if (results.Success)
            {
                return View(results.Data);
            }
            return View();
        }
    }
}
