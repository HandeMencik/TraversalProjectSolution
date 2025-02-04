using Entity.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TraversalReservationProject.Models;

namespace TraversalReservationProject.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public LoginController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }


        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(UserRegisterViewModel userRegister)
        {
            AppUser appUser = new AppUser()
            {
                Name = userRegister.Name,
                Surname = userRegister.Surname,
                Email = userRegister.Email,
                UserName = userRegister.UserName

            };
            if (userRegister.Password == userRegister.ConfirmPassword)
            {
                var result = await _userManager.CreateAsync(appUser, userRegister.Password);

                if (result.Succeeded)
                {
                    return RedirectToAction("SignIn", "Login");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }
            return View();
        }

        public IActionResult SignIn()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignIn(UserSignInViewModel userSignIn)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(userSignIn.UserName, userSignIn.Password, false, true);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Profile",new {area="Member"});
                }
                else
                {
                    return RedirectToAction("SignIn", "Login");
                }
            }
            return View();
        }

    }
}
