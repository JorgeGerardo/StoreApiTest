using Bussiness.Models;
using Bussiness.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StoreApiTest.Services;

namespace StoreApiTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IGenericRepository<User> _users;

        public UserController(IConfiguration _configuration, IGenericRepository<User> _users)
        {
            this._configuration = _configuration;
            this._users = _users;
        }


        [HttpPost("/api/login"), AllowAnonymous]
        public async Task<ActionResult<string>> Login(UserLoginDto userData)
        {
            var user = await _users.GetAll()
                .FirstOrDefaultAsync(u => 
                    u.Email == userData.Email &&
                    u.HashPassword == TokenService.EncrypBySHA256(userData.Password));

            if (user is null)
                return NotFound(new ProblemDetails { Detail = "User not found"});

            JWTConfig? jwt = _configuration.GetSection("JWT").Get<JWTConfig>();

            if (jwt is null) return
                    StatusCode(500);

            var token = TokenService.GenerateToken(user, jwt);
            return Ok(new UserAuth { Token = token, UserId = user.Id});
        }
    }

}
