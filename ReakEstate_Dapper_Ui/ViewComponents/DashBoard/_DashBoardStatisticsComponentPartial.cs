using Microsoft.AspNetCore.Mvc;
using System.Net.Http;

namespace ReakEstate_Dapper_Ui.ViewComponents.DashBoard
{
    public class _DashBoardStatisticsComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public _DashBoardStatisticsComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            #region Statistics1 - ToplamİlanSayısı
            var client1 = _httpClientFactory.CreateClient();
            var responseMessage1 = await client1.GetAsync("https://localhost:44350/api/Statistics/ProductCount");
            var jsondata1 = await responseMessage1.Content.ReadAsStringAsync();
            ViewBag.ProductCount = jsondata1;
            #endregion        

            #region Statistics2 - EnBaşarılıPersonel
            var client2 = _httpClientFactory.CreateClient();
            var responseMessage2 = await client2.GetAsync("https://localhost:44350/api/Statistics/EmployeeNameByMaxProductCount");
            var jsondata2 = await responseMessage2.Content.ReadAsStringAsync();
            ViewBag.EmployeeNameByMaxProductCount = jsondata2;
            #endregion

            #region Statistics3 - İlandakiŞehirSayıları
            var client3 = _httpClientFactory.CreateClient();
            var responseMessage3 = await client3.GetAsync("https://localhost:44350/api/Statistics/DifferentCityCount");
            var jsondata3 = await responseMessage3.Content.ReadAsStringAsync();
            ViewBag.DifferentCityCount = jsondata3;
            #endregion

            #region Statistics4 - OrtalamaKiraFiyatı
            var client4 = _httpClientFactory.CreateClient();
            var responseMessage4 = await client4.GetAsync("https://localhost:44350/api/Statistics/AvergeProductPriceByRent");
            var jsondata4 = await responseMessage4.Content.ReadAsStringAsync();
            ViewBag.avergeProductPriceByRent = jsondata4;
            #endregion
            return View();
        }
    }
}