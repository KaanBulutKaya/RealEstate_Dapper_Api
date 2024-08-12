using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ReakEstate_Dapper_Ui.Dtos.ProductDetailDtos;
using ReakEstate_Dapper_Ui.Dtos.ProductDtos;

namespace ReakEstate_Dapper_Ui.Controllers
{
    public class HomeDealsOfTheDayController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public HomeDealsOfTheDayController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44350/api/Products/GetProductByDealOfTheDayTrueWithCategory");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultProductDto>>(jsonData);
                return View(values);
            }
            return View();
        }
        
    }
}
