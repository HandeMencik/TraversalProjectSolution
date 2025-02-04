using Entity.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace TraversalReservationProject.Areas.Member.Controllers
{
    [Area("Member")]
    public class DashboardController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public DashboardController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var results = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.userName = results.Name + " " + results.Surname;
            ViewBag.userImage = results.ImageUrl; 
            return View();
        }
    }
}
