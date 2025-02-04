using Business.Abstract;
using Core.Utilities.Results;
using Entity.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace TraversalReservationProject.Controllers
{
    public class DestinationController : Controller
    {
        private readonly IDestinationService _destinationService;

        public DestinationController(IDestinationService destinationService)
        {
            _destinationService = destinationService;
        }

        public IActionResult Index()
        {
            var results = _destinationService.GetAll();
            if (results.Success)
            {
                return View(results.Data);
            }
            return View();
        }

        public async Task<IActionResult> DestinationDetails(int id)
        {
            ViewBag.Id = id;
            var result = _destinationService.GetById(id);
            if (result.Success)
            {
                return View(result.Data);
            }
            return View(new Destination());

        }
        [HttpPost]
        public IActionResult DestinationDetails(Destination destination)
        {
            return View();
        }
    }
}
