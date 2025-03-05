using Business.Abstract;
using Entity.Concrete;
using Microsoft.AspNetCore.Mvc;
using TraversalReservationProject.Areas.Admin.Models;

namespace TraversalReservationProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AccountController : Controller
    {
      private readonly  IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(AccountViewModel model)
        {
            var SenderResult = _accountService.GetById(model.SenderId);
            var RecieverResult= _accountService.GetById(model.RecieverId);
         

            SenderResult.Data.Balance-= model.Amount;
            RecieverResult.Data.Balance += model.Amount;

            List<Account> modifiedAccounts = new List<Account>()
            {
            SenderResult.Data,
            RecieverResult.Data
            };
            _accountService.MultiUpdate(modifiedAccounts);

            return View();
        }
    }
}
