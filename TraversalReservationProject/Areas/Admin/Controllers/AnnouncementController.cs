using AutoMapper;
using Business.Abstract;
using Entity.Concrete;
using Entity.Dto_s;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TraversalReservationProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AnnouncementController : Controller
    {
        private readonly IAnnouncementService _announcementService;
        private readonly IMapper _mapper;

        public AnnouncementController(IAnnouncementService announcementService, IMapper mapper)
        {
            _announcementService = announcementService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var results = _announcementService.GetAll();
            if (results.Success)
            {
                return View(results.Data);
            }
            return View();
        }
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(AnnouncementAddDto model)
        {
            if (!ModelState.IsValid) // Eğer model geçerli değilse, hatalarla tekrar formu göster
            {
                return View(model);
            }

            _announcementService.Add(new AnnouncementAddDto()
            {
                Content = model.Content,
                Title = model.Title,
            
            });
            return Redirect("/Admin/Announcement/Index");
        

        }
        public IActionResult Delete(int id)
        {
            var result=_announcementService.GetById(id);
            _announcementService.Delete(result.Data);
            return Redirect("/Admin/Announcement/Index");

        }
        public IActionResult Update(int id)
        {
         
            var result = _announcementService.GetById(id);

            if (!result.Success || result.Data == null)
            {
                return NotFound("Güncellenecek duyuru bulunamadı.");
            }

            var updateDto = _mapper.Map<AnnouncementUpdateDto>(result.Data);
                        return View(updateDto);

        }
        [HttpPost]
        public IActionResult Update(AnnouncementUpdateDto announcementUpdateDto)
        {
            if (!ModelState.IsValid)
            {
                return View(announcementUpdateDto);
            }
            var result=_announcementService.Update(announcementUpdateDto);
            if (result.Success)
            {
                return Redirect("/Admin/Announcement/Index");
            }
            return View(announcementUpdateDto);
        }
    }
}
