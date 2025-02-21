using Core.DataAccess.EntityFramework;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IGuideDal:IEntityRepository<Guide>
    {
        void ChangeToTrueByGuide(int id);
        void ChangeToFalseByGuide(int id);
    }
}
