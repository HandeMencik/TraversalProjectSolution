using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using TraversalReservationProject.Areas.Admin.Models;

namespace TraversalReservationProject.Areas.Admin.Controllers
{
    [AllowAnonymous]
    [Area("Admin")]

    public class VisitorApiController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public VisitorApiController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7250/api/Visitor");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<VisitorViewModel>>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(VisitorViewModel visitorViewModel)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(visitorViewModel);
            Console.WriteLine("Gönderilen JSON: " + jsonData); // Log ekleyelim
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7250/api/Visitor", content);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Admin/VisitorApi/Index");
            }

            Console.WriteLine("POST isteği başarısız!");
            return View();
        }

        public async Task<IActionResult> Delete(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7250/api/Visitor/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Admin/VisitorApi/Index");
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7250/api/Visitor/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<VisitorViewModel>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Update(VisitorViewModel visitorViewModel)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(visitorViewModel);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7250/api/Visitor", content);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Admin/VisitorApi/Index");
            }
                   
            return View();

        }
    }
}
