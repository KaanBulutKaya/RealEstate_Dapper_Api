using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Repositories.AppUserListRepositories;
using RealEstate_Dapper_Api.Repositories.AppUserRepositories;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppUsersListController : ControllerBase
    {
        private readonly IAppUserListRepository _appUserListRepository;

        public AppUsersListController(IAppUserListRepository appUserListRepository)
        {
            _appUserListRepository = appUserListRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAppUserByProduct()
        {
            var values = await _appUserListRepository.GetAppUserByProduct();
            return Ok(values);
        }


    }
}
