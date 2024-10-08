﻿using Dapper;
using RealEstate_Dapper_Api.Dtos.AppUserDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.AppUserRepositories
{
    public class AppUserRepository : IAppUserRepository
    {
        private readonly Context _context;

        public AppUserRepository(Context context)
        {
            _context = context;
        }

        

        public async Task<GetAppUserByProductID> GetAppUserByProductID(int id)
        {
            string query = "Select * from AppUser Where UserID=@userID";
            var parameters = new DynamicParameters();
            parameters.Add("@userID", id);
            using var connection = _context.CreateConnection();
            {
                var values = await connection.QueryFirstOrDefaultAsync<GetAppUserByProductID>(query, parameters);
                return values;
            }
        }
    }
}
