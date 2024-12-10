using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using RentACar.Dto.BrandDtos;
using RentACar.Dto.CarDtos;
using System.Text;

namespace RentACar.WebUI.Areas.Admin.Controllers
{
    public class AdminCarController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IMapper _mapper;
        public AdminCarController(IHttpClientFactory httpClientFactory, IMapper mapper)
        {
            _httpClientFactory = httpClientFactory;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7290/api/Cars/GetCarWithBrand");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCarWithBrandsDtos>>(jsonData);
                return View(values);
            }
            return View();

        }
        [HttpGet]
        public async Task<IActionResult> CreateCar()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7290/api/Brands");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var brandDtos = JsonConvert.DeserializeObject<List<ResultBrandDto>>(jsonData);  
            return View(new CreateCarDto { Brands = brandDtos });
           
        }

        [HttpPost]
        public async Task<IActionResult> CreateCar(CreateCarDto createCarDto)
        {
            var map = _mapper.Map<ResultCar>(createCarDto);
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(map);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7290/api/Cars", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> RemoveCar(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7290/api/Cars/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateCar(int id)
        {
            var client = _httpClientFactory.CreateClient();

            var responseMessage1 = await client.GetAsync("https://localhost:7290/api/Brands");
            var jsonData1 = await responseMessage1.Content.ReadAsStringAsync();
            var brands = JsonConvert.DeserializeObject<List<ResultBrandDto>>(jsonData1);
            var resposenMessage = await client.GetAsync($"https://localhost:7290/api/Cars/{id}");
            if (resposenMessage.IsSuccessStatusCode)
            {
                var jsonData = await resposenMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateCarDto>(jsonData);
                var map = _mapper.Map<UpdateCarDto>(values);
                map.Brands = brands;
                return View(map);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCar(UpdateCarDto updateCarDto)
        {
            var map = _mapper.Map<ResultCar>(updateCarDto);
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(map);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7290/api/Cars/", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            var responseMessage1 = await client.GetAsync("https://localhost:7290/api/Brands");
            var jsonData1 = await responseMessage1.Content.ReadAsStringAsync();
            var brands = JsonConvert.DeserializeObject<List<ResultBrandDto>>(jsonData1);
            updateCarDto.Brands = brands;
            return View(updateCarDto);
        }
    }
}
