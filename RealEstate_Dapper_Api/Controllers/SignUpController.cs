using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Dtos.SignUpDtos;
using RealEstate_Dapper_Api.Models.DapperContext;
using RealEstate_Dapper_Api.Tools;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SignUpController : ControllerBase
    {
        private readonly Context _context;
        public SignUpController(Context context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(CreateSignUpDto signUpDto)
        {
            string checkQuery = "Select * From AppUser Where UserName=@username";
            var parameters = new DynamicParameters();
            parameters.Add("@username", signUpDto.UserName);

            using (var connection = _context.CreateConnection())
            {
                var existingUser = await connection.QueryFirstOrDefaultAsync<GetAppUserIDDtos>(checkQuery, parameters);

                if (existingUser != null)
                {
                    return BadRequest("Bu kullanıcı adı zaten mevcut.");
                }

                string insertQuery = "Insert Into AppUser (UserName, Password, Email) Values (@username, @password, @Email)";
                parameters.Add("@password", signUpDto.Password);
                parameters.Add("@Email", signUpDto.Email);

                await connection.ExecuteAsync(insertQuery, parameters);

                // Yeni eklenen kullanıcıyı al
                string getUserQuery = "Select * From AppUser Where UserName=@username";
                var newUser = await connection.QueryFirstOrDefaultAsync<GetAppUserIDDtos>(getUserQuery, parameters);

                // JWT token oluştur
                if (newUser != null)
                {
                    GetCheckAppUserViewModel model = new GetCheckAppUserViewModel
                    {
                        UserName = newUser.UserName,
                        ID = newUser.UserID,
                    };

                    // JWT token oluştur
                    var token = JwtTokenGenerator.GenerateToken(model);
                    return Ok(token);
                }
                else
                {
                    return BadRequest("Yeni kullanıcı oluşturulamadı.");
                }
            }

        }
    }
}
