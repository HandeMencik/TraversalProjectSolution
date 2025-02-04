using Entity.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace TraversalReservationProject.ViewComponents.MemberDashboard
{
    public class _ProfileInformationComponentPartial:ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;

        public _ProfileInformationComponentPartial(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var results = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.userName = results.Name + " " + results.Surname;
            ViewBag.userPhone = results.PhoneNumber;
            ViewBag.userMail= results.Email;
            return View();
          
        }

    }
}
