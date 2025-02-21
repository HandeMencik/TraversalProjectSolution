using Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dto_s
{
    public class CityAddDto:IDto
    {
        public int CityId { get; set; }
        public string CityName { get; set; }
        public string CityCountry { get; set; }
    }
}
