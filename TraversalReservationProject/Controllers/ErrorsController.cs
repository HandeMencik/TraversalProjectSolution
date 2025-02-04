using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TraversalReservationProject.Controllers
{
    [AllowAnonymous]
    public class ErrorsController : Controller
    {
        [Route("hata/404")]
        public IActionResult PageNotFound()
        {
            return View();
        }
    }
}
