using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Entity.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace TraversalReservationProject.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class GuideController : Controller
	{
		private readonly IGuideService _guideService;

		public GuideController(IGuideService guideService)
		{
			_guideService = guideService;
		}

		public IActionResult Index()
		{
			var results=_guideService.GetAll();
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
        public IActionResult Add(Guide guide)
        {
			GuideValidator validationRules=new GuideValidator();
			ValidationResult result=validationRules.Validate(guide);
            if (result.IsValid)
            {
                _guideService.Add(guide);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
					ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
				return View();
            }


        }
		public IActionResult Update(int id)
		{
			var result=_guideService.GetById(id);
			return View(result.Data);
		}
		[HttpPost]
        public IActionResult Update(Guide guide)
        {
			_guideService.Update(guide);
			return RedirectToAction("Index");
        }
        public IActionResult ChangeStatus(int id)
        {
            var guide = _guideService.GetById(id);
            if (guide.Success && guide.Data != null)
            {
                guide.Data.Status = !guide.Data.Status; // Mevcut durumu tersine çevir
                _guideService.Update(guide.Data);

                // Yeni durumu JSON olarak döndür
                return Json(new { success = true, newStatus = guide.Data.Status });
            }

            return Json(new { success = false });
        }
  //      public IActionResult ChangeToTrue(int id)
		//{
		//	return RedirectToAction("Index");
		//}
  //      public IActionResult ChangeToFalse(int id)
  //      {
  //          return RedirectToAction("Index");
  //      }
    }
}
