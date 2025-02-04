using DataAccess.Context;
using Microsoft.AspNetCore.Mvc;

namespace TraversalReservationProject.ViewComponents.Default
{
    public class _StatisticsDefaultPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            using var c = new TraversalContext();
            ViewBag.v=c.Destinations.Count();
            ViewBag.v1 = c.Guides.Count();
            ViewBag.v2 = "285";

            return View();
        }
    }
}
