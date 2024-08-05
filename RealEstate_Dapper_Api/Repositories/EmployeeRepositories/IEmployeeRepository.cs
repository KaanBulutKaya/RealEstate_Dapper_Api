﻿using RealEstate_Dapper_Api.Dtos.EmployeeDtos;

namespace RealEstate_Dapper_Api.Repositories.EmployeeRepositories
{
    public interface IEmployeeRepository
    {
        Task<List<ResultEmployeeDto>> GetAllEmployeeAsync();
        Task CreateEmployee(CreateEmployeeDto createEmployeeDto);
        Task DeleteEmployee(int id);
        Task UptadeEmployee(UpdateEmployeeDto updateEmployeeDto);
        Task<GetByIDEmployeeDto> GetEmployee(int id);
    }
}
