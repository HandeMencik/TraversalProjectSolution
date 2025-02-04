using Microsoft.AspNetCore.Mvc;

namespace TraversalReservationProject.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
