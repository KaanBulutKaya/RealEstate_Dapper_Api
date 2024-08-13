using Dapper;
using RealEstate_Dapper_Api.Dtos.AppUserDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.AppUserListRepositories
{
    public class AppUserListRepository : IAppUserListRepository
    {
        private readonly Context _context;

        public AppUserListRepository(Context context)
        {
            _context = context;
        }

        public async Task<List<ResultAppUserProductDto>> GetAppUserByProduct()
        {
            string query = "Select * From AppUser";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultAppUserProductDto>(query);
                return values.ToList();
            }
        }
    }
}
