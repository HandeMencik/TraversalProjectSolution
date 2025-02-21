using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using TraversalReservationProject.Areas.Admin.Models;
using static OfficeOpenXml.ExcelErrorValue;

namespace TraversalReservationProject.Areas.Admin.Controllers
{
    [AllowAnonymous]
    [Area("Admin")]
    public class BookingHotelSearchController : Controller
    {
        public async Task<IActionResult> Index()
        {

            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://booking-com15.p.rapidapi.com/api/v1/hotels/searchHotels?dest_id=20079942&search_type=CITY&arrival_date=2025-02-14&departure_date=2025-02-18&adults=2&room_qty=1&page_number=1&units=metric&temperature_unit=c&languagecode=en-us&currency_code=EUR"),
                Headers =
    {
        { "x-rapidapi-key", "04a3f4f3e3msh8c91993fe8005fap176624jsn5fccd8a1aeb7" },
        { "x-rapidapi-host", "booking-com15.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<BookingHotelSearchViewModel>(body);
                return View(values);

            }

        }
    }
}
