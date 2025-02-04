using Microsoft.AspNetCore.Mvc;

namespace TraversalReservationProject.ViewComponents.AdminDashboard
{
    public class _AdminGuideListPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
