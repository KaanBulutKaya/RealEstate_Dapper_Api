using RealEstate_Dapper_Api.Dtos.CustomerMailDtos;

namespace RealEstate_Dapper_Api.Repositories.CustomerMailRepositories
{
    public interface ICustomerMailReposityory
    {
        Task CreateCustomerMail(CreateCustomerMailDto createCustomerMailDto);

    }
}
