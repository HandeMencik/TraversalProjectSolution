using Business.Abstract;
using Entity.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace TraversalReservationProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly IAppUserService _appUserService;
        private readonly IReservationService _reservationService;

        public UserController(IAppUserService appUserService, IReservationService reservationService)
        {
            _appUserService = appUserService;
            _reservationService = reservationService;
        }

        public IActionResult Index()
        {
            var results=_appUserService.GetAll();
            if (results.Success)
            {
                return View(results.Data);
            }
            return View();
        }
        public IActionResult Delete(string id)
        {
            var result = _appUserService.GetById(id);
            _appUserService.Delete(result.Data);
            return RedirectToAction("Index");
        }
        public IActionResult EditUSer(string id)
        {
            var result = _appUserService.GetById(id);
            return View(result.Data);
        }
        [HttpPost]
        public IActionResult EditUSer(AppUser appUser)
        {
            _appUserService.Update(appUser);
            return RedirectToAction("Index");
        }
        public IActionResult CommentUser(string id)
        {
            _appUserService.GetById(id);
            return View();
        }
        public IActionResult ReservationUser(string id)
        {
            var result = _reservationService.GetListWithByAccepted(id);
            return View(result.Data);
        }
    }
}
