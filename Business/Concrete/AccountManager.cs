using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.UnitOfWork;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class AccountManager : IAccountService
    {
        IAccountDal _accountDal;
        IUnitOfWork _unitOfWork;

        public AccountManager(IAccountDal accountDal, IUnitOfWork unitOfWork)
        {
            _accountDal = accountDal;
            _unitOfWork = unitOfWork;
        }

        public IResult Add(Account account)
        {
            _accountDal.Add(account);
            _unitOfWork.Save();
            return new SuccessResult();
        }

        public IResult Delete(Account account)
        {
            _accountDal.Delete(account);
            _unitOfWork.Save();
            return new SuccessResult();
        }

        public IDataResult<List<Account>> GetAll()
        {
           return new SuccessDataResult<List<Account>>(_accountDal.GetAll());
        }

        public IDataResult<Account> GetById(int id)
        {
          return new SuccessDataResult<Account>(_accountDal.Get(x=>x.AccountId== id));  
        }

        public void MultiUpdate(List<Account> accounts)
        {
           _accountDal.MultiUpdate(accounts);
            _unitOfWork.Save();
         
        }

        public IResult Update(Account account)
        {
            _accountDal.Update(account);
            _unitOfWork.Save();
            return new SuccessResult();
        }
    }
}
