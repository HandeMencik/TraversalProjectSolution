using DataAccess.Context;
using Microsoft.AspNetCore.Mvc;

namespace TraversalReservationProject.ViewComponents.Default
{
    public class _StatisticsDefaultPartial : ViewComponent
    {
        private readonly TraversalContext _context;

		public _StatisticsDefaultPartial(TraversalContext context)
		{
			_context = context;
		}

		public IViewComponentResult Invoke()
        {
          
            ViewBag.v=_context.Destinations.Count();
            ViewBag.v1 = _context.Guides.Count();
            ViewBag.v2 = "285";

            return View();
        }
    }
}
