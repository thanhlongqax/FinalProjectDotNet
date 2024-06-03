using Gimji.DTO;
using Gimji.Models;
using Gimji.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Gimji.Controllers
{

    [Route("api/login")]
    [ApiController]
    [AllowAnonymous]
    public class LoginController : ControllerBase
    {
        private EmployeeRepository emloyeeRepository;
        private JWTRepository jwtRepository;
        
        public LoginController(EmployeeRepository emloyeeRepository, JWTRepository jWTRepository)
        {
            this.emloyeeRepository = emloyeeRepository;
            this.jwtRepository = jWTRepository;
        }

        // POST api/<LoginController>
        [HttpPost]
        public async Task<IActionResult> loginRequest([FromBody] LoginRequest loginRequest)
        {
            var user = await emloyeeRepository.GetEmployeeByUserName(loginRequest.username);
            if (user != null) 
            {
                if(user.accountPassword == loginRequest.password)
                {
                    // Định nghĩa thời gian hết hạn, ví dụ: hết hạn sau 30 phút từ thời điểm hiện tại
                    DateTime expireTime = (DateTime.Now).AddMinutes(30);
                    var tokenString = jwtRepository.GenerateTokenAccount(user,expireTime);
                    return Ok(new { token = tokenString });
                }

            }
            return Ok();
        }

    }
}
