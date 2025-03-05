using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete;
using DataAccess.UnitOfWork;
using Entity.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CommentManager : ICommentService
    {
        ICommentDal _commentDal;
        IUnitOfWork _unitOfWork;
        UserManager<AppUser> _userManager;
        IHttpContextAccessor _httpContextAccessor;

        public CommentManager(ICommentDal commentDal, IUnitOfWork unitOfWork, UserManager<AppUser> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _commentDal = commentDal;
            _unitOfWork = unitOfWork;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }

        public Core.Utilities.Results.IResult Add(Comment comment)
        {
            var currentUser = _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User).Result;
            if (currentUser != null)
            {
                comment.AppUserId = currentUser.Id;
            }
            _commentDal.Add(comment);
            _unitOfWork.Save();
            return new SuccessResult();
        }

        public Core.Utilities.Results.IResult Delete(Comment comment)
        {
            _commentDal.Delete(comment);
            _unitOfWork.Save();
            return new SuccessResult();
        }

        public IDataResult<List<Comment>> GetAll()
        {
            return new SuccessDataResult<List<Comment>>(_commentDal.GetAll());
        }

        public IDataResult<Comment> GetById(int id)
        {
            return new SuccessDataResult<Comment>(_commentDal.Get(x => x.CommentId == id));
        }

        public IDataResult<List<Comment>> GetDestinationById(int? destinationId = null)
        {
            if (destinationId == null)
            {
                return new SuccessDataResult<List<Comment>>(_commentDal.GetDestinationById(x=>true)); // Tüm yorumları getir
            }

            return new SuccessDataResult<List<Comment>>(_commentDal.GetDestinationById(x => x.DestinationId == destinationId));
        }

     

        public Core.Utilities.Results.IResult Update(Comment comment)
        {
            _commentDal.Update(comment);
            _unitOfWork.Save();
            return new SuccessResult();
        }

    }
}
