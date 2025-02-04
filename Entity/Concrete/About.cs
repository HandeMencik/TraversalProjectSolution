using Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class About : IEntity
    {
        public int AboutId { get; set; }
        public string MainTitle { get; set; }
        public string MainDescription { get; set; }
        public string ImageUrl { get; set; }
        public string SubTitle { get; set; }
        public string SubDescription { get; set; }
        public bool Status { get; set; }
    }
}
