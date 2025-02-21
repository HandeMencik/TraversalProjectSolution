using AutoMapper;
using Entity.Concrete;
using Entity.Dto_s;

namespace TraversalReservationProject.Mapping.AutoMapperProfile
{
    public class MapProfile:Profile
    {
        public MapProfile()
        {
            CreateMap<AnnouncementAddDto, Announcement>();
            CreateMap<Announcement,AnnouncementAddDto>();

            CreateMap<AnnouncementListDto, Announcement>();
            CreateMap<Announcement, AnnouncementListDto>();

            CreateMap<AnnouncementUpdateDto, Announcement>();
            CreateMap<Announcement, AnnouncementUpdateDto>();

            CreateMap<AppUserLoginDto, AppUser>();
            CreateMap<AppUser, AppUserLoginDto>();

            CreateMap<AppUserRegisterDto, AppUser>();
            CreateMap<AppUser, AppUserRegisterDto>();

            CreateMap<DestinationAddDto, Destination>();
            CreateMap<Destination, DestinationAddDto>();
        }
    }
}
