using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RentACar.Dto.OurServiceDtos;
using System.Text;

namespace RentACar.WebUI.Areas.Admin.Controllers
{
    public class AdminOurServiceController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public AdminOurServiceController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7290/api/OurServices");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultOurServiceDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpGet]
        
        public IActionResult CreateOurService()
        {
            return View();
        }

        [HttpPost]
       
        public async Task<IActionResult> CreateOurService(CreateOurServiceDto createOurServiceDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createOurServiceDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7290/api/OurServices", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "AdminOurService", new { area = "Admin" });
            }
            return View();
        }

      
        public async Task<IActionResult> RemoveOurService(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync("https://localhost:7290/api/OurServices?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "AdminOurService", new { area = "Admin" });
            }
            return View();
        }

        [HttpGet]
        
        public async Task<IActionResult> UpdateOurService(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var resposenMessage = await client.GetAsync($"https://localhost:7290/api/OurServices/{id}");
            if (resposenMessage.IsSuccessStatusCode)
            {
                var jsonData = await resposenMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateOurServiceDto>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpPost]
        
        public async Task<IActionResult> UpdateOurService(UpdateOurServiceDto updateOurServiceDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateOurServiceDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7290/api/OurServices/", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "AdminOurService", new { area = "Admin" });
            }
            return View();
        }
    }
}
