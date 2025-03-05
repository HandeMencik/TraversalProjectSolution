using Core.Utilities.Results;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IAccountService
    {
        IResult Add(Account account);
        IResult Delete(Account account);
        IResult Update(Account account);
        IDataResult<List<Account>> GetAll();
        IDataResult<Account> GetById(int id);
        void MultiUpdate(List<Account> accounts);
    }
}
