using Core.Utilities.Results;
using Entity.Concrete;
using Entity.Dto_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IAnnouncementService
    {
        IResult Add(AnnouncementAddDto announcementAddDto);
        IResult Delete(Announcement announcement);
        IResult Update(AnnouncementUpdateDto announcementUpdateDto);
        IDataResult<List<AnnouncementListDto>> GetAll();
        IDataResult<Announcement> GetById(int id);
    }
}
