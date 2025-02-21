using Core.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dto_s
{
    public class AppUserLoginDto:IDto
    {

        public string UserName { get; set; }

        public string Password { get; set; }
    }
}
