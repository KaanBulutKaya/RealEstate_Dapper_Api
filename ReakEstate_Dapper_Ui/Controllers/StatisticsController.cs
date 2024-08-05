using Microsoft.AspNetCore.Mvc;

namespace ReakEstate_Dapper_Ui.Controllers
{
    public class StatisticsController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public StatisticsController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            #region Statistics1
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44350/api/Statistics/ActiveCategoryCount");
            var jsondata=await responseMessage.Content.ReadAsStringAsync();
            ViewBag.activeCategoryCount = jsondata;
            #endregion
            #region Statistics2
            var client2 = _httpClientFactory.CreateClient();
            var responseMessage2 = await client2.GetAsync("https://localhost:44350/api/Statistics/ActiveEmployeeCount");
            var jsondata2 = await responseMessage2.Content.ReadAsStringAsync();
            ViewBag.activeEmployeeCount = jsondata2;
            #endregion
            #region Statistics3
            var client3 = _httpClientFactory.CreateClient();
            var responseMessage3 = await client3.GetAsync("https://localhost:44350/api/Statistics/ApartmenCount");
            var jsondata3 = await responseMessage3.Content.ReadAsStringAsync();
            ViewBag.activeApartmenCount = jsondata3;
            #endregion
            #region Statistics4
            var client4 = _httpClientFactory.CreateClient();
            var responseMessage4 = await client4.GetAsync("https://localhost:44350/api/Statistics/AvergeProductPriceByRent");
            var jsondata4 = await responseMessage4.Content.ReadAsStringAsync();
            ViewBag.avergeProductPriceByRent = jsondata4;
            #endregion

            //5-8

            #region Statistics5
            var client5 = _httpClientFactory.CreateClient();
            var responseMessage5 = await client5.GetAsync("https://localhost:44350/api/Statistics/AvargeProductPriceBySale");
            var jsondata5 = await responseMessage5.Content.ReadAsStringAsync();
            ViewBag.AvargeProductPriceBySale = jsondata5;
            #endregion
            #region Statistics6
            var client6 = _httpClientFactory.CreateClient();
            var responseMessage6 = await client6.GetAsync("https://localhost:44350/api/Statistics/AvereageRoomCount");
            var jsondata6 = await responseMessage6.Content.ReadAsStringAsync();
            ViewBag.AvereageRoomCount = jsondata6;
            #endregion
            #region Statistics7
            var client7 = _httpClientFactory.CreateClient();
            var responseMessage7 = await client7.GetAsync("https://localhost:44350/api/Statistics/CategoryCount");
            var jsondata7 = await responseMessage7.Content.ReadAsStringAsync();
            ViewBag.CategoryCount = jsondata7;
            #endregion
            #region Statistics8
            var client8 = _httpClientFactory.CreateClient();
            var responseMessage8 = await client8.GetAsync("https://localhost:44350/api/Statistics/CategoryNameByMaxProductCount");
            var jsondata8 = await responseMessage8.Content.ReadAsStringAsync();
            ViewBag.CategoryNameByMaxProductCount = jsondata8;
            #endregion

            //9-12

            #region Statistics9
            var client9 = _httpClientFactory.CreateClient();
            var responseMessage9 = await client9.GetAsync("https://localhost:44350/api/Statistics/CityNameByMaxProductCount");
            var jsondata9 = await responseMessage9.Content.ReadAsStringAsync();
            ViewBag.CityNameByMaxProductCount = jsondata9;
            #endregion
            #region Statistics10
            var client10 = _httpClientFactory.CreateClient();
            var responseMessage10 = await client10.GetAsync("https://localhost:44350/api/Statistics/DifferentCityCount");
            var jsondata10 = await responseMessage10.Content.ReadAsStringAsync();
            ViewBag.DifferentCityCount = jsondata10;
            #endregion
            #region Statistics11
            var client11 = _httpClientFactory.CreateClient();
            var responseMessage11 = await client11.GetAsync("https://localhost:44350/api/Statistics/EmployeeNameByMaxProductCount");
            var jsondata11 = await responseMessage11.Content.ReadAsStringAsync();
            ViewBag.EmployeeNameByMaxProductCount = jsondata11;
            #endregion
            #region Statistics12
            var client12 = _httpClientFactory.CreateClient();
            var responseMessage12 = await client12.GetAsync("https://localhost:44350/api/Statistics/LastProductPrice");
            var jsondata12 = await responseMessage12.Content.ReadAsStringAsync();
            ViewBag.LastProductPrice = jsondata12;
            #endregion

            //13-16

            #region Statistics13
            var client13 = _httpClientFactory.CreateClient();
            var responseMessage13 = await client13.GetAsync("https://localhost:44350/api/Statistics/NewestBuildingYear");
            var jsondata13 = await responseMessage13.Content.ReadAsStringAsync();
            ViewBag.NewestBuildingYear = jsondata13;
            #endregion
            #region Statistics14
            var client14 = _httpClientFactory.CreateClient();
            var responseMessage14 = await client14.GetAsync("https://localhost:44350/api/Statistics/OldestBuildingYear");
            var jsondata14 = await responseMessage14.Content.ReadAsStringAsync();
            ViewBag.OldestBuildingYear = jsondata14;
            #endregion
            #region Statistics15
            var client15 = _httpClientFactory.CreateClient();
            var responseMessage15 = await client15.GetAsync("https://localhost:44350/api/Statistics/PassiveCategoryCount");
            var jsondata15 = await responseMessage15.Content.ReadAsStringAsync();
            ViewBag.PassiveCategoryCount = jsondata15;
            #endregion
            #region Statistics16
            var client16 = _httpClientFactory.CreateClient();
            var responseMessage16 = await client16.GetAsync("https://localhost:44350/api/Statistics/ProductCount");
            var jsondata16 = await responseMessage16.Content.ReadAsStringAsync();
            ViewBag.ProductCount = jsondata16;
            #endregion

            return View();
        }
    }
}
