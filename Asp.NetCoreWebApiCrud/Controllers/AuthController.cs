using Asp.NetCoreWebApiCrud.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Asp.NetCoreWebApiCrud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly IConfiguration _configuration;
        private readonly CodeFirstDbContext db;

        public AuthController(IConfiguration configuration,CodeFirstDbContext db)
        {
            this._configuration = configuration;
            this.db = db;
        }

        [HttpPost]
        [Route("Token")]
        public IActionResult userIsValid([FromBody] UserCredential ul)
        {
           UserCredential? uc = db.UserCredentials.FirstOrDefault(u => ul.Username == u.Username && ul.Password == u.Password);

            if (uc!=null)
            {
                var userDetails = "Amit";
                if (userDetails != null)
                {
                    var claims = new Claim[]
                    {
                    new Claim(JwtRegisteredClaimNames.Sub,"APIUser"),
                    new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                        

                    };

                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:SecretKey"]));
                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    var token = new JwtSecurityToken(
                    issuer: _configuration["Jwt:Issuer"],
                    audience: _configuration["Jwt:Audience"],
                    claims: claims,
                    expires: DateTime.Now.AddHours(1),
                    signingCredentials: signIn
                );
                    var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

                    return Ok(new { Token = tokenString });
                  
                }
            }
            else
            {
                return Unauthorized("Invalid User Or User Not Found");
            }
             return Unauthorized("Invalid User Or User Not Found");
           
        }
    }
}
