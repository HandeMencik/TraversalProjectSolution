using Core.Utilities.Results;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IReservationService
    {
        IResult Add(Reservation reservation);
        IResult Delete(Reservation reservation);
        IResult Update(Reservation reservation);
        IDataResult<List<Reservation>> GetAll();
        IDataResult<Reservation> GetById(int id);
        IDataResult<List<Reservation>> GetReservationById(string id);
        IDataResult<List<Reservation>> GetListWithByWaitApproval(string id);
        IDataResult<List<Reservation>> GetListWithByPrevious(string id);
        IDataResult<List<Reservation>> GetListWithByAccepted(string id);
    }
}
