﻿using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RentACar.Dto.BannerDtos;

namespace RentACar.WebUI.ViewComponents.DefaultViewComponents
{
    public class DefaultCoverLayoutComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public DefaultCoverLayoutComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7290/api/Banners");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultBannerDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
