using Business.Abstract;
using Core.Utilities.Results;
using Entity.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace TraversalReservationProject.Controllers
{
    public class DestinationController : Controller
    {
        private readonly IDestinationService _destinationService;
        private readonly ICommentService _commentService;

        public DestinationController(IDestinationService destinationService, ICommentService commentService)
        {
            _destinationService = destinationService;
            _commentService = commentService;
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
        [HttpGet]
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
        public IActionResult DestinationDetails(Destination destination,Comment comment)
        {
            // Yorumun hangi destinasyona ait olduğunu belirt
            comment.DestinationId = destination.DestinationId;

            Console.WriteLine($"Comment: {comment.Content}, DestinationId: {comment.DestinationId}");
            // Yorum ekleme işlemi
            var result = _commentService.Add(comment);

            if (result.Success)
            {
                return RedirectToAction("DestinationDetails", new { id = destination.DestinationId });
            }

            // Eğer bir hata varsa, aynı sayfayı tekrar göster
            return View(destination);
        }
    }
}
