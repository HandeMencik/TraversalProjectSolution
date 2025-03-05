using Core.Entity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class AppUser : IdentityUser,IEntity
    {
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Gender { get; set; }
        public string? ImageUrl { get; set; }
        public virtual List<Reservation> Reservations { get; set; }
        public virtual List<Comment> Comments { get; set; }
    }
}
