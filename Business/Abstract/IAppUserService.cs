using Core.Utilities.Results;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IAppUserService
    {
        IResult Add(AppUser appUser);
        IResult Delete(AppUser appUser);
        IResult Update(AppUser appUser);
        IDataResult<List<AppUser>> GetAll();
        IDataResult<AppUser> GetById(string id);
    }
}
