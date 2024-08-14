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
            string query = "Select * from AppUser";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultAppUserProductDto>(query);
                return values.ToList();
            }
        }

        public async Task<ResultAppUserProductDto> GetAppUserByProductListID(int id)
        {
            string query = "Select * from AppUser Where UserID=@userID";
            var parameters = new DynamicParameters();
            parameters.Add("@userID", id);
            using var connection = _context.CreateConnection();
            {
                var values = await connection.QueryFirstOrDefaultAsync<ResultAppUserProductDto>(query, parameters);
                return values;
            }
        }
    }
}
