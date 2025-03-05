using Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class Account:IEntity
    {
        public int AccountId { get; set; }
        public string Name { get; set; }
        public decimal  Balance { get; set; }
    }
}
