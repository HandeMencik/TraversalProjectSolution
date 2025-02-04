using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TraversalReservationProject.Models;

namespace TraversalReservationProject.Controllers
{
  
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        [HttpGet]
        public IActionResult Get()
        {
            _logger.LogInformation(" Dosya Loglama Ba�ar�l�!");
            _logger.LogWarning(" Warning: Bu bir uyar� mesaj�d�r.");
            _logger.LogError(" Error: Bu bir hata mesaj�d�r.");

            return Ok("Log dosyaya kaydedildi!");
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
