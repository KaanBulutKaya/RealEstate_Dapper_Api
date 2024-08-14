using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ReakEstate_Dapper_Ui.Dtos.ProductDetailDtos;
using ReakEstate_Dapper_Ui.Dtos.ProductDtos;

namespace ReakEstate_Dapper_Ui.ViewComponents.AppUser
{
    public class _AppUserIDListProduct: ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public _AppUserIDListProduct(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44350/api/Products/GetProdcutByAppUser?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<GetProductByProductIdDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
