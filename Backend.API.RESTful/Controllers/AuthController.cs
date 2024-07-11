using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Backend.API.RESTful.Controllers
{
    [ApiController]
    [Route("api/web/v1/auth")]
    public class AuthController : Controller
    {
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginModel login)
        {
            // Validar usuario (es solo un ejemplo, se deberia validar contra una base de datos)
            if (login.Username == "admin" && login.Password == "1234")
            {
                var token = JwtGenerateToken(login.Username);

                return Ok(new { token });
            }

            return StatusCode(StatusCodes.Status401Unauthorized);
        }

        private string JwtGenerateToken(string username)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, username),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("esta_es_una_clave_secreta_muy_segura_12345"));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: "tu_issuer",
                audience: "tu_audience",
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}

public class LoginModel
{
    [Required(ErrorMessage = "Required field")]
    [DataType(DataType.Text)]
    [MaxLength(20)]
    [DefaultValue("Username")]
    public string Username { get; set; }

    [Required(ErrorMessage = "Required field")]
    [DataType(DataType.Text)]
    [MaxLength(20)]
    [DefaultValue("Password")]
    public string Password { get; set; }
}
