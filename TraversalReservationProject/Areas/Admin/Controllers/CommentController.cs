using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace TraversalReservationProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CommentController : Controller
    {
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        public IActionResult Index()
        {
            var results=_commentService.GetDestinationById();
            if (results.Success)
            {
                return View(results.Data);
            }
            return View();
        }
        public IActionResult Delete(int id)
        {
            var result = _commentService.GetById(id);
            _commentService.Delete(result.Data);
            return RedirectToAction("Index");
        }
    }
}
