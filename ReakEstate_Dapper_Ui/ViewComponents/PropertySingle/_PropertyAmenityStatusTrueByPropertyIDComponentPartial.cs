﻿using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ReakEstate_Dapper_Ui.Dtos.PropertyAmenityDtos;

namespace ReakEstate_Dapper_Ui.ViewComponents.PropertySingle
{
    public class _PropertyAmenityStatusTrueByPropertyIdComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public _PropertyAmenityStatusTrueByPropertyIdComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44350/api/PropertyAmenitys?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultPropertyAmenityByStatusTrueDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
