﻿using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RentACar.Dto.LocationDtos;
using System.Net.Http.Headers;
using System.Text;

namespace RentACar.WebUI.Areas.Admin.Controllers
{
    public class AdminLocationController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public AdminLocationController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        
        public async Task<IActionResult> Index()
        {
            var token = User.Claims.FirstOrDefault(x => x.Type == "carbooktoken")?.Value;
            if (token != null)
            {
                var client = _httpClientFactory.CreateClient();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var responseMessage = await client.GetAsync("https://localhost:7290/api/Location");
                if (responseMessage.IsSuccessStatusCode)
                {
                    var jsonData = await responseMessage.Content.ReadAsStringAsync();
                    var values = JsonConvert.DeserializeObject<List<ResultLocationDto>>(jsonData);
                    return View(values);
                }
            }
            return View();

        }

        [HttpGet]
       
        public IActionResult CreateLocation()
        {
            return View();
        }

        [HttpPost]
       
        public async Task<IActionResult> CreateLocation(CreateLocationDto createLocationDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createLocationDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7290/api/Locations", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "AdminLocation", new { area = "Admin" });
            }
            return View();
        }

        
        public async Task<IActionResult> RemoveLocation(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync("https://localhost:7290/api/Locations?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "AdminLocation", new { area = "Admin" });
            }
            return View();
        }

        [HttpGet]
       
        public async Task<IActionResult> UpdateLocation(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var resposenMessage = await client.GetAsync($"https://localhost:7290/api/Locations/{id}");
            if (resposenMessage.IsSuccessStatusCode)
            {
                var jsonData = await resposenMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateLocationDto>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpPost]
       
        public async Task<IActionResult> UpdateLocation(UpdateLocationDto updateLocationDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateLocationDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7290/api/Locations/", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "AdminLocation", new { area = "Admin" });
            }
            return View();
        }
    }
}
