using AutoMapper;
using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.UnitOfWork;
using Entity.Concrete;
using Entity.Dto_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class AnnouncementManager : IAnnouncementService
    {
        IAnnouncementDal _announcementDal;
        IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AnnouncementManager(IAnnouncementDal announcementDal, IMapper mapper)
        {
            _announcementDal = announcementDal;
            _mapper = mapper;
        }

        public IResult Add(AnnouncementAddDto announcementAddDto)
        {
         
            Announcement announcement=_mapper.Map<Announcement>(announcementAddDto);
            announcement.Date = DateTime.Now;
            _announcementDal.Add(announcement);
            _unitOfWork.Save();
            return new SuccessResult();
        }

        public IResult Delete(Announcement announcement)
        {
            _announcementDal.Delete(announcement);
            _unitOfWork.Save();
            return new SuccessResult();
        }

        public IDataResult<List<AnnouncementListDto>> GetAll()
        {
            var announcementEntities=_announcementDal.GetAll();
            var results=_mapper.Map<List<AnnouncementListDto>>(announcementEntities);
            return new SuccessDataResult<List<AnnouncementListDto>>(results);
        }

        public IDataResult<Announcement> GetById(int id)
        {
            return new SuccessDataResult<Announcement>(_announcementDal.Get(x=>x.AnnouncementId==id));
        }

        public IResult Update(AnnouncementUpdateDto announcementUpdateDto)
        {
            var existingAnnouncement=_announcementDal.Get(x=>x.AnnouncementId==announcementUpdateDto.AnnouncementId);
            if (existingAnnouncement == null)
            {
                return new ErrorResult("Güncellenecek duyuru bulunamadı");
               
            }
           _mapper.Map(announcementUpdateDto,existingAnnouncement);
            _announcementDal.Update(existingAnnouncement);
            _unitOfWork.Save();
            return new SuccessResult();
        }
    }
}
