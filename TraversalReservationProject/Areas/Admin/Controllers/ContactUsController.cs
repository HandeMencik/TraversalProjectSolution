using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace TraversalReservationProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ContactUsController : Controller
    {
        private readonly IContactUsService _contactUsService;

        public ContactUsController(IContactUsService contactUsService)
        {
            _contactUsService = contactUsService;
        }

        public IActionResult Index()
        {
            var results= _contactUsService.GetListByTrue();
            if (results.Success)
            {
                return View(results.Data);
            }
            return View();
        }
    }
}
