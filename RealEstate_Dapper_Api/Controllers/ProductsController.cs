using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Dtos.ProductDto;
using RealEstate_Dapper_Api.Repositories.ProductRepository;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public async Task<IActionResult> ProductList()
        {
            var values = await _productRepository.GetAllProductAsync();
            return Ok(values);
        }

        [HttpGet("ProductListWithCategory")]
        public async Task<IActionResult> ProductListWithCategory()
        {
            var values = await _productRepository.GetAllProductWithCategoryAsync();
            return Ok(values);
        }
        [HttpGet("ProductDealOfTheDayStatusChangeToTrue/{id}")]
        public async Task<IActionResult> ProductDealOfTheDayStatusChangeToTrue(int id)
        {
            _productRepository.ProductDealOfTheDayStatusChangeToTrue(id);
            return Ok("İlan Günün Fırsatları Arasına Eklendi");
        }

        [HttpGet("ProductDealOfTheDayStatusChangeToFalse/{id}")]
        public async Task<IActionResult> ProductDealOfTheDayStatusChangeToFalse(int id)
        {
            _productRepository.ProductDealOfTheDayStatusChangeToFalse(id);
            return Ok("İlan Günün Fırsatları Arasından Çıkarıldı");
        }
        [HttpGet("Last5ProductList")]
        public async Task<IActionResult> Last5ProductList()
        {
            var values = await _productRepository.GetLast5ProductAsync();
            return Ok(values);
        }
        [HttpGet("ProductAdvertsListByEmployeeByTrue")]
        public async Task<IActionResult> ProductAdvertsListByEmployeeByTrue(int id)
        {
            var values = await _productRepository.GetProductAdvertListByEmployeeAsyncByTrue(id);
            return Ok(values);
        }

        [HttpGet("ProductAdvertListByEmployeeByFalse")]
        public async Task<IActionResult> ProductAdvertListByEmployeeByFalse(int id)
        {
            var values = await _productRepository.GetProductAdvertListByEmployeeAsyncByFalse(id);
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CretaeProduct(CreateProductDto createProductDto)
        {
            await _productRepository.CreateProduct(createProductDto);
            return Ok("İlan başarıyla eklendi");
        }

        [HttpGet("GetProductByProductId")]
        public async Task<IActionResult> GetProductByProductId(int id)
        {
            var values = await _productRepository.GetProductByProductId(id);
            return Ok(values);
        }
        [HttpGet("ResultProductWithSearchList")]
        public async Task<IActionResult> ResultProductWithSearchList(string searchKeyValue, int propertyCategoryId, string city)
        {
            var values= await _productRepository.resultProductWithSearchList(searchKeyValue, propertyCategoryId, city);
            return Ok(values);
        }
        [HttpGet("ResultProductWithNavbarSearchList")]
        public async Task<IActionResult> ResultProductWithNavbarSearchList(string searchKeyValue)
        {
            var values = await _productRepository.resultProductWithNavbarSearchList(searchKeyValue);
            return Ok(values);
        }
        [HttpGet("GetProductByDealOfTheDayTrueWithCategory")]
        public async Task<IActionResult> GetProductByDealOfTheDayTrueWithCategory()
        {
            var values = await _productRepository.GetProductByDealOfTheDayTrueWithCategoryAsync();
            return Ok(values);

		}
        [HttpGet("Last3ProductList")]
        public async Task<IActionResult> Last3ProductList()
        {
            var values = await _productRepository.GetLast3ProductAsync();
            return Ok(values);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            await _productRepository.DeleteProduct(id);
            return Ok("Personel Başarılı Bir Şekilde Silindi");
        }
        [HttpPut]
        public async Task<IActionResult> UptadeProduct(UpdateProductDto updateProductDto)
        {
            await _productRepository.UptadeProduct(updateProductDto);
            return Ok("Personel Başarılı Bir Şekilde Güncellendi");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProdcut(int id)
        {
            var value = await _productRepository.GetProdcut(id);
            return Ok(value);
        }
        [HttpGet("GetProductByCityWithCategory")]
        public async Task<IActionResult> GetProductByCityWithCategory(string city)
        {
            var values = await _productRepository.GetProductByCityWithCategoryAsync(city);
            return Ok(values);
        }
        [HttpGet("GetProdcutByAppUser")]
        public async Task<IActionResult> GetProdcutByAppUser(int id)
        {
            var values = await _productRepository.GetProdcutByAppUserID(id);
            return Ok(values);
        }
    }
}
