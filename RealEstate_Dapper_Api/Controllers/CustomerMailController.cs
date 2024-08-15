using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Dtos.CustomerMailDtos;
using RealEstate_Dapper_Api.Repositories.BottomGridRepositories;
using RealEstate_Dapper_Api.Repositories.CustomerMailRepositories;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerMailController : ControllerBase
    {
        private readonly ICustomerMailReposityory _customerMailReposityory;

        public CustomerMailController(ICustomerMailReposityory customerMailReposityory)
        {
            _customerMailReposityory = customerMailReposityory;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCustomerMail(CreateCustomerMailDto createCustomerMailDto)
        {
            await _customerMailReposityory.CreateCustomerMail(createCustomerMailDto);
            return Ok("Mesajınız Başarılı Şekilde Gönderildi");

        }


    }
}
