using Core.DataAccess.EntityFramework;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IReservationDal:IEntityRepository<Reservation>
    {
        List<Reservation> GetReservationById(Expression<Func<Reservation, bool>> filter);
        List<Reservation> GetListWithByWaitApproval(string id);
        List<Reservation> GetListWithByAccepted(string id);
        List<Reservation> GetListWithByPrevious(string id);

    }
}
