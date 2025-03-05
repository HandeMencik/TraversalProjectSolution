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
    public class AppUserManager : IAppUserService
    {
        IAppUserDal _appUserDal;
        IUnitOfWork _unitOfWork;

        public AppUserManager(IAppUserDal appUserDal, IUnitOfWork unitOfWork)
        {
            _appUserDal = appUserDal;
            _unitOfWork = unitOfWork;
        }

        public IResult Add(AppUser appUser)
        {
            _appUserDal.Add(appUser);
            _unitOfWork.Save();
            return new SuccessResult();
        }

        public IResult Delete(AppUser appUser)
        {
            _appUserDal.Delete(appUser);
            _unitOfWork.Save();
            return new SuccessResult();
        }

        public IDataResult<List<AppUser>> GetAll()
        {
            return new SuccessDataResult<List<AppUser>>(_appUserDal.GetAll());
        }

        public IDataResult<AppUser> GetById(string id)
        {
            return new SuccessDataResult<AppUser>(_appUserDal.Get(x => x.Id == id));
        }

        public IResult Update(AppUser appUser)
        {
            _appUserDal.Update(appUser);
            _unitOfWork.Save();
            return new SuccessResult();
        }
    }
}
