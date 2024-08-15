using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ReakEstate_Dapper_Ui.Dtos.ContactDtos;
using System.Net.Http;
using System.Text;

namespace ReakEstate_Dapper_Ui.Controllers
{
    public class ContactController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public ContactController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(CreateCustomerMailDto createCustomerMailDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsondate = JsonConvert.SerializeObject(createCustomerMailDto);
            StringContent stringContent = new StringContent(jsondate, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:44350/api/CustomerMail", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");

            }
            return View();
        }

    }
}
