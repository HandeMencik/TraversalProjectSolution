using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entity.Concrete;
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

        public CommentManager(ICommentDal commentDal)
        {
            _commentDal = commentDal;
        }

        public IResult Add(Comment comment)
        {
            _commentDal.Add(comment);
            return new SuccessResult();
        }

        public IResult Delete(Comment comment)
        {
            _commentDal.Delete(comment);
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
                return new SuccessDataResult<List<Comment>>(_commentDal.GetAll()); // Tüm yorumları getir
            }

            return new SuccessDataResult<List<Comment>>(_commentDal.GetDestinationById(x => x.DestinationId == destinationId));
        }




        public IResult Update(Comment comment)
        {
            _commentDal.Delete(comment);
            return new SuccessResult();
        }
    }
}
