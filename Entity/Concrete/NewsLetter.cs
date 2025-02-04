using Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class NewsLetter : IEntity
    {
        public int NewsLetterId { get; set; }
        public string Mail { get; set; }
    }
}
