using Microsoft.AspNetCore.Mvc;

namespace TraversalReservationProject.ViewComponents.AdminDashboard
{
    public class _DashboardBannerPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
