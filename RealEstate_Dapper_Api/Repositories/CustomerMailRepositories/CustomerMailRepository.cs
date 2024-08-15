using Dapper;
using RealEstate_Dapper_Api.Dtos.CustomerMailDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.CustomerMailRepositories
{
    public class CustomerMailRepository:ICustomerMailReposityory
    {
        private readonly Context _context;

        public CustomerMailRepository(Context context)
        {
            _context = context;
        }

        public async Task CreateCustomerMail(CreateCustomerMailDto createCustomerMailDto)
        {
            string query = "insert into CustomerMail (Email, UserName, Message) values (@email, @userName, @message)";
            var parameters = new DynamicParameters();
            parameters.Add("@email", createCustomerMailDto.Email);
            parameters.Add("@userName", createCustomerMailDto.UserName);
            parameters.Add("@message", createCustomerMailDto.Message);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
