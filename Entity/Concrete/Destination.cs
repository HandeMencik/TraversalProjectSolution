using Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class Destination : IEntity
    {
        public int DestinationId { get; set; }
        public string City { get; set; }
        public string Description { get; set; }
        public int Capacity { get; set; }
        public string DayNight { get; set; }
        public double Price { get; set; }
        public string Image { get; set; }
        public string ImageTwo { get; set; }
        public bool Status { get; set; }
        public string CoverImage { get; set; }
        public string Detail { get; set; }
        public string DetailTwo { get; set; }
        public List<Comment> Comments { get; set; }
        public List<Reservation> Reservations { get; set; }


    }
}
