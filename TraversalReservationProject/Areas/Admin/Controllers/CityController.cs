using Business.Abstract;
using Entity.Concrete;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TraversalReservationProject.Models;

namespace TraversalReservationProject.Areas.Admin.Controllers
{

    [Area("Admin")]
    public class CityController : Controller
    {
        private readonly IDestinationService _destinationService;

        public CityController(IDestinationService destinationService)
        {
            _destinationService = destinationService;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult CityList()
        {

            var results = _destinationService.GetAll(); // Veritabanından tüm şehirleri al
            if (results.Success)
            {
                Console.WriteLine("Dönen JSON: " + JsonConvert.SerializeObject(results.Data)); // JSON verisini ekrana yaz
                return Json(results.Data);
            }
            Console.WriteLine("HATA: Veri çekilemedi!");
            return Json(new { success = false, message = "Veri bulunamadı!" });


        }
        [HttpPost]
        public IActionResult AddCity([FromBody] Destination newCity)
        {
            try
            {
                if (newCity == null)
                {
                    Console.WriteLine("HATA: AJAX isteği ile gelen veri NULL!");
                    return Json(new { success = false, message = "Gönderilen veri boş!" });
                }

                Console.WriteLine("Gelen Şehir: " + JsonConvert.SerializeObject(newCity));

                var result = _destinationService.Add(newCity);

                if (result.Success)
                {
                    Console.WriteLine("Şehir başarıyla eklendi!");
                    return Json(new { success = true, message = "Şehir başarıyla eklendi." });
                }

                Console.WriteLine("HATA: Şehir eklenemedi! Hata mesajı: " + result.Message);
                return Json(new { success = false, message = "Şehir eklenirken hata oluştu: " + result.Message });
            }
            catch (Exception ex)
            {
                Console.WriteLine("❌ SERVER HATASI: " + ex.Message);
                return Json(new { success = false, message = "Sunucu hatası: " + ex.Message });
            }
        }

        [HttpGet]
        public IActionResult GetById(int id)
        {
            try
            {
                var result = _destinationService.GetById(id);

                if (result == null || result.Data == null)
                {
                    Console.WriteLine($"❌ HATA: ID {id} ile eşleşen şehir bulunamadı.");
                    return Json(new { success = false, message = $"ID {id} ile eşleşen şehir bulunamadı." });
                }

                return Json(new { success = true, data = result.Data });
            }
            catch (Exception ex)
            {
                Console.WriteLine("❌ SUNUCU HATASI: " + ex.Message);
                return Json(new { success = false, message = "Sunucu hatası: " + ex.Message });
            }
        }
        public IActionResult Delete(int id)
        {
            var result = _destinationService.GetById(id);
            _destinationService.Delete(result.Data);
            return NoContent();
        }
        [HttpPut]
        public IActionResult Update([FromBody] Destination updatedCity)
        {
            try
            {
                if (updatedCity == null || updatedCity.DestinationId == 0)
                {
                    Console.WriteLine("❌ HATA: Güncelleme için geçerli bir şehir ID'si girilmedi.");
                    return Json(new { success = false, message = "Geçerli bir şehir ID girilmelidir!" });
                }

                var result = _destinationService.Update(updatedCity);

                if (!result.Success)
                {
                    Console.WriteLine($"❌ HATA: ID {updatedCity.DestinationId} ile eşleşen şehir güncellenemedi.");
                    return Json(new { success = false, message = $"ID {updatedCity.DestinationId} ile eşleşen şehir bulunamadı!" });
                }

                return Json(new { success = true, message = "Şehir başarıyla güncellendi!" });
            }
            catch (Exception ex)
            {
                Console.WriteLine("❌ SUNUCU HATASI: " + ex.Message);
                return Json(new { success = false, message = "Sunucu hatası: " + ex.Message });
            }
        }



    }
    }
