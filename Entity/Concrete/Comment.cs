using Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class Comment:IEntity
    {
        public int CommentId { get; set; }
        public string? CommentUser { get; set; }
        public DateTime? CommentDate { get; set; }
        public string? Content { get; set; }
        public bool? Status { get; set; }
        public int DestinationId { get; set; }
        public Destination Destination { get; set; }
        public string AppUserId { get; set; }
        public virtual AppUser AppUser { get; set; }
    }
}
