using Business.Abstract;
using Entity.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace TraversalReservationProject.Areas.Admin.Controllers
{
    [Area("Admin")]
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
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Destination destination)
        {
            _destinationService.Add(destination);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var result = _destinationService.GetById(id);
            _destinationService.Delete(result.Data);
            return RedirectToAction("Index");
        }
        public IActionResult Update(int id)
        {
            var result = _destinationService.GetById(id);
            return View(result.Data);
        }
        [HttpPost]
        public IActionResult Update(Destination destination)
        {
            _destinationService.Update(destination);
            return RedirectToAction("Index");
        }
    }
}
