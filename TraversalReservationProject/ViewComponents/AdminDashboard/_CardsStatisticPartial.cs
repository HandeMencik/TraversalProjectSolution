using DataAccess.Context;
using Microsoft.AspNetCore.Mvc;

namespace TraversalReservationProject.ViewComponents.AdminDashboard
{
    public class _CardsStatisticPartial:ViewComponent
    {
      
          TraversalContext context=new TraversalContext();
            public IViewComponentResult Invoke()
            {
                ViewBag.v1 = context.Destinations.Count();
                ViewBag.v2 = context.Users.Count();
                return View();
            }
       
    }
}
