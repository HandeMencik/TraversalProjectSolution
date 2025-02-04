using Entity.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TraversalReservationProject.Areas.Member.Models;

namespace TraversalReservationProject.Areas.Member.Controllers
{
    [Area("Member")]
    [Route("Member/[controller]/[action]")]
    public class ProfileController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public ProfileController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            UserEditViewModel userEditViewModel = new UserEditViewModel();
            userEditViewModel.name = values.Name;
            userEditViewModel.surname = values.Surname;
            userEditViewModel.email = values.Email;
            userEditViewModel.phoneNumber = values.PhoneNumber;

            return View(userEditViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Index(UserEditViewModel userEdit)
        {
            //forograf ekleme
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            if (userEdit.Image!=null)
            {
                var resource = Directory.GetCurrentDirectory();
                var extension=Path.GetExtension(userEdit.Image.FileName);
                var imageName= Guid.NewGuid()+extension;
                var savelocation = resource + "/wwwroot/userimages/" + imageName;
                var stream= new FileStream(savelocation, FileMode.Create);
                await userEdit.Image.CopyToAsync(stream);
                user.ImageUrl = imageName;
            }
            //Bilgileri güncelleme
            user.Name = userEdit.name;
            user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, userEdit.password);
            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                return RedirectToAction("SignIn", "Login");
            }


            return View();
        }
    }
}
