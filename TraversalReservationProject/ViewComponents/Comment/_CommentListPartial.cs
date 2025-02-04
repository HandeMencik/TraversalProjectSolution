using Business.Abstract;
using DataAccess.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace TraversalReservationProject.ViewComponents.Comment
{
    public class _CommentListPartial:ViewComponent
    {
      private readonly ICommentService _commentService;

        public _CommentListPartial(ICommentService commentService)
        {
            _commentService = commentService;
        }

        public IViewComponentResult Invoke(int id)
        {
            var results = _commentService.GetDestinationById(id);
            return View(results.Data);
        }
    }
}
