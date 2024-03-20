using LMS__Elibrary_BE.Services.AuthServices;
using LMS__Elibrary_BE.Services.RoleServices;
using LMS__Elibrary_BE.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace LMS__Elibrary_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class AuthController : Controller
    {
        private readonly IAuthService _authService;
        private readonly IConfiguration _configuration;
        private readonly IRoleService _roleService;
        public AuthController(IAuthService authService, IConfiguration configuration, IRoleService roleService)
        {
            _authService = authService;
            _configuration = configuration;
            _roleService = roleService;
        }

        [HttpPost("user/login")]
        public async Task<ActionResult> UserLogin(ViewLogin login)
        {
            try
            {
                string token = null;
                var result = await _authService.UserLogin(login);
                if (result != null)
                {
                    var role = _roleService.GetRoleById(result.RoleId).Result.Name;
                    token = CreateToken(login.Email, role);
                    return Ok(token);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch(Exception ex) 
            {
                return BadRequest(ex.Message);
            }
           
        }
        [HttpPost("student/login")]
        public async Task<ActionResult> StudentLogin(ViewLogin login)
        {
            try
            {
                string token = null;
                var result = await _authService.StudentLogin(login);
                if(result != null)
                {
                    token = CreateToken(login.Email, "Student");
                    return Ok(token);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        private string CreateToken(string email, string role)
        {
            List<Claim> claims = new List<Claim>() {
                new Claim(ClaimTypes.Name, email),
                new Claim(ClaimTypes.Role, role),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                _configuration["AppSettings:Token"]!));

            var creads = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                    claims: claims,
                    expires: DateTime.Now.AddHours(3),
                    signingCredentials: creads
                );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }
    }
}
