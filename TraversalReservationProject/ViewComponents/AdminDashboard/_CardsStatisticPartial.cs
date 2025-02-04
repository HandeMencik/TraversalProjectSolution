using DataAccess.Context;
using Microsoft.AspNetCore.Mvc;

namespace TraversalReservationProject.ViewComponents.AdminDashboard
{
    public class _CardsStatisticPartial:ViewComponent
    {
        private readonly TraversalContext _context;

        public _CardsStatisticPartial(TraversalContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
            {
                ViewBag.v1 = _context.Destinations.Count();
                ViewBag.v2 = _context.Users.Count();
                return View();
            }
       
    }
}
