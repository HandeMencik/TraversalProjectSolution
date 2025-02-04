using Business.Abstract;
using Entity.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace TraversalReservationProject.Areas.Member.Controllers
{
    [Area("Member")]
    public class ReservationController : Controller
    {
        private readonly IDestinationService _destinationService;
        private readonly IReservationService _reservationService;
        private readonly UserManager<AppUser> _userManager;

        public ReservationController(IDestinationService destinationService, IReservationService reservationService, UserManager<AppUser> userManager)
        {
            _destinationService = destinationService;
            _reservationService = reservationService;
            _userManager = userManager;
        }

        public async Task<IActionResult> CurrentReservation()
        {
            var results = await _userManager.FindByNameAsync(User.Identity.Name);
            var resultsList = _reservationService.GetListWithByAccepted(results.Id).Data;
            return View(resultsList);
        }
        public async Task<IActionResult> PastReservation()
        {
            var results = await _userManager.FindByNameAsync(User.Identity.Name);
            var resultsList = _reservationService.GetListWithByPrevious(results.Id).Data;
            return View(resultsList);
        }
        public async Task<IActionResult> ApprovalReservation()
        {
            var results = await _userManager.FindByNameAsync(User.Identity.Name);
            var resultsList = _reservationService.GetListWithByWaitApproval(results.Id).Data;
            return View(resultsList);
        }
        public IActionResult NewReservation()
        {
            var result = _destinationService.GetAll(); 
            if (result.Success) 
            {
                List<SelectListItem> values = result.Data.Select(x => new SelectListItem
                {
                    Text = x.City,
                    Value = x.DestinationId.ToString()
                }).ToList();

                ViewBag.Values = values;
            }
            else
            {
                ViewBag.Values = new List<SelectListItem>(); 
            }

            return View();
        }
        [HttpPost]
        public IActionResult NewReservation(Reservation reservation)
        {
            reservation.AppUserId = "90f6e932-b6e8-461b-b62f-d1549495c72a";
            reservation.Status = "Onay bekliyor";
            _reservationService.Add(reservation);
            return RedirectToAction("CurrentReservation");
        }
    }
}
