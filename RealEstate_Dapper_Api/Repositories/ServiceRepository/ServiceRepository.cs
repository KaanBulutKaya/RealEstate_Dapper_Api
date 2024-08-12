using Dapper;
using RealEstate_Dapper_Api.Dtos.ServiceDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.ServiceRepository
{
    public class ServiceRepository : IServiceRepository
    {
        private readonly Context _context;

        public ServiceRepository(Context context)
        {
            _context = context;
        }

        public async Task CreateService(CreateServiceDto createServiceDto)
        {
            string query = "insert into Services (ServiceName, ServiceStatus) values (@serviceName, @ServiceStatus)";
            var parameters = new DynamicParameters();
            parameters.Add("@serviceName", createServiceDto.ServiceName);
            parameters.Add("@ServiceStatus", createServiceDto.ServiceStatus);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task DeleteService(int id)
        {
            string query = "Delete From Services Where ServiceID=@ServiceID";
            var parameters = new DynamicParameters();
            parameters.Add("@ServiceID", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<ResultServiceDto>> GetAllServiceAsync()
        {
            string query = "SELECT * FROM Services";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultServiceDto>(query);
                return values.ToList();
            }
        }

        public async Task<GetByIDServiceDto> GetService(int id)
        {
            string query = "SELECT * FROM Services WHERE ServiceID=@ServiceID";
            var parameters = new DynamicParameters();
            parameters.Add("@ServiceID", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<GetByIDServiceDto>(query, parameters);
                return values;
            }
        }

        public async Task UptadeService(UpdateServiceDto updateServiceDTo)
        {
            string query = "Update Services Set ServiceName=@serviceName, ServiceStatus=@ServiceStatus where ServiceID=@ServiceID";
            var parameters = new DynamicParameters();
            parameters.Add("@ServiceName", updateServiceDTo.ServiceName);
            parameters.Add("@ServiceStatus", updateServiceDTo.ServiceStatus);
            parameters.Add("@ServiceID", updateServiceDTo.ServiceID);
            using var connection = _context.CreateConnection();
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
