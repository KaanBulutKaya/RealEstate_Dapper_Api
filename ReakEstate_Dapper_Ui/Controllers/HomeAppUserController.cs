using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ReakEstate_Dapper_Ui.Dtos.AppUserDtos;
using System.Net.Http;

namespace ReakEstate_Dapper_Ui.Controllers
{
    public class HomeAppUserController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public HomeAppUserController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44350/api/AppUsersList");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultAppUserProductDto>>(jsonData);
                return View(values);
            }
            return View();

        }
    }
}
