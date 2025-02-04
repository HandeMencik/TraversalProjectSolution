using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Context;
using Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class EfReservationDal : EfEntityRepositoryBase<Reservation, TraversalContext>, IReservationDal
    {
        private readonly TraversalContext _context;
        public EfReservationDal(TraversalContext context) : base(context)
        {
            _context = context;
        }

        public List<Reservation> GetListWithByAccepted(string id)
        {

            return _context.Reservations.Include(x => x.Destination).Where(x => x.Status == "Onaylandı" && x.AppUserId == id).ToList();

        }

        public List<Reservation> GetListWithByPrevious(string id)
        {
        
                return _context.Reservations.Include(x => x.Destination).Where(x => x.Status == "Geçmiş Rezervasyon" && x.AppUserId == id).ToList();
            
        }

        public List<Reservation> GetListWithByWaitApproval(string id)
        {
          
                return _context.Reservations.Include(x => x.Destination).Where(x => x.Status == "onay Bekliyor" && x.AppUserId == id).ToList();
            

        }

        public List<Reservation> GetReservationById(Expression<Func<Reservation, bool>> filter)
        {
           
                return _context.Reservations.Where(filter).ToList();
            
        }
    }
}
