using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete;
using DataAccess.UnitOfWork;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ReservationManager:IReservationService
    {
        IReservationDal _reservationDal;
        IUnitOfWork _unitOfWork;

        public ReservationManager(IReservationDal reservationDal, IUnitOfWork unitOfWork)
        {
            _reservationDal = reservationDal;
            _unitOfWork = unitOfWork;
        }

        public IResult Add(Reservation reservation)
        {
           _reservationDal.Add(reservation);
            _unitOfWork.Save();
            return new SuccessResult();
        }

        public IResult Delete(Reservation reservation)
        {
            _reservationDal.Delete(reservation);
            _unitOfWork.Save();
            return new SuccessResult();
        }

        public IDataResult<List<Reservation>> GetAll()
        {
         return new SuccessDataResult<List<Reservation>>(_reservationDal.GetAll());
        }

        public IDataResult<Reservation> GetById(int id)
        {
            return new SuccessDataResult<Reservation>(_reservationDal.Get(x=>x.ReservationId==id));
        }

        public IDataResult<List<Reservation>> GetListWithByAccepted(string id)
        {
            return new SuccessDataResult<List<Reservation>>(_reservationDal.GetListWithByAccepted(id));
        }

        public IDataResult<List<Reservation>> GetListWithByPrevious(string id)
        {
            return new SuccessDataResult<List<Reservation>>(_reservationDal.GetListWithByPrevious(id));
        }

        public IDataResult<List<Reservation>> GetListWithByWaitApproval(string id)
        {
            return new SuccessDataResult<List<Reservation>>(_reservationDal.GetListWithByWaitApproval(id));
        }
        public IResult Update(Reservation reservation)
        {
            _reservationDal.Update(reservation);
            _unitOfWork.Save();
            return new SuccessResult();
        }
        public IDataResult<List<Reservation>> GetReservationById(string id)
        {
            throw new NotImplementedException();
        }

     
    }
}
