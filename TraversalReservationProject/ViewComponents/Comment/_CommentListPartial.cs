using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Context;
using Microsoft.AspNetCore.Mvc;

namespace TraversalReservationProject.ViewComponents.Comment
{
    public class _CommentListPartial:ViewComponent
    {
      private readonly ICommentService _commentService;
        private readonly TraversalContext _context;

        public _CommentListPartial(ICommentService commentService, TraversalContext context)
        {
            _commentService = commentService;
            _context = context;
        }

        public IViewComponentResult Invoke(int id)
        {
            ViewBag.commentCount=_context.Comments.Where(x=>x.DestinationId==id).Count();
            var results = _commentService.GetDestinationById(id);
            return View(results.Data);
        }
    }
}
