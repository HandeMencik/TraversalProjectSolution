using Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class Reservation:IEntity
    {
        public int ReservationId { get; set; }    
        public string AppUserId { get; set; }
        public virtual AppUser AppUser { get; set; }
        public string Personcount { get; set; }    
        public DateTime ReservationDate { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public int DestinationId { get; set; }
        public Destination Destination { get; set; }
    }
}
