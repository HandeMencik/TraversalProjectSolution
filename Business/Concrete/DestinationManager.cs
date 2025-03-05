using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.UnitOfWork;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class DestinationManager : IDestinationService
    {
        IDestinationDal _destinationDal;
        IUnitOfWork _unitOfWork;


        public DestinationManager(IDestinationDal destinationDal, IUnitOfWork unitOfWork)
        {
            _destinationDal = destinationDal;
            _unitOfWork = unitOfWork;
        }

        public IResult Add(Destination destination)
        {
          _destinationDal.Add(destination);
            _unitOfWork.Save();
            return new SuccessResult();
        }

        public IResult Delete(Destination destination)
        {
            _destinationDal.Delete(destination);
            _unitOfWork.Save();
            return new SuccessResult();
        }

        public IDataResult<List<Destination>> GetAll()
        {
         return new SuccessDataResult<List<Destination>>(_destinationDal.GetAll());
        }

        public IDataResult<Destination> GetById(int id)
        {
         return new SuccessDataResult<Destination>(_destinationDal.Get(x=>x.DestinationId == id));
        }

        public IResult Update(Destination destination)
        {
           _destinationDal.Update(destination);
            _unitOfWork.Save();
            return new SuccessResult();
        }
    }
}
