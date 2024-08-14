using RealEstate_Dapper_Api.Dtos.AppUserDtos;

namespace RealEstate_Dapper_Api.Repositories.AppUserListRepositories
{
    public interface IAppUserListRepository
    {
        Task<List<ResultAppUserProductDto>> GetAppUserByProduct();
        Task<ResultAppUserProductDto> GetAppUserByProductListID(int id);

    }
}
