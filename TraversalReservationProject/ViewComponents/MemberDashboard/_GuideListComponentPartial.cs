using Business.Abstract;
using Business.Concrete;
using Entity.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace TraversalReservationProject.ViewComponents.MemberDashboard
{
    public class _GuideListComponentPartial : ViewComponent
    {
        private readonly IGuideService _guideService;

        public _GuideListComponentPartial(IGuideService guideService)
        {
            _guideService = guideService;
        }

        public IViewComponentResult Invoke()
        {
            var results = _guideService.GetAll();
            return View(results.Data);
        }
    }
}
