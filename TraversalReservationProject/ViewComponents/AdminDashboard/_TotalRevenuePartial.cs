using Microsoft.AspNetCore.Mvc;

namespace TraversalReservationProject.ViewComponents.AdminDashboard
{
    public class _TotalRevenuePartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
