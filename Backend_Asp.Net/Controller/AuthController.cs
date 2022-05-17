using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using server.Business.Abstarct;
using server.Entities.DTOs;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace server.Business.Concrete
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAllService _service;
        private readonly IConfiguration _configuration;
        public AuthController(IConfiguration configuration)
        {
            _service = new AllManager();
            _configuration = configuration;
        }

        [HttpPost("login")]
        public IActionResult Login(AuthDto model)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = _service.login(model.KullaniciAdi, model.Sifre);

            if(result != null)
            {
                return Ok(new
                {
                    token = GenerateJwtToken(result)
                });
            }
            else
            {
                return BadRequest(new { message = "bilgiler yanlış" });
            }

            return Unauthorized();
        }

        private string GenerateJwtToken(AuthDto user)
        {
            string tur;
            if (user.Türü == 1)
                tur = "ogrenci";
            else if (user.Türü == 2)
                tur = "ogretmen";
            else
                tur = "admin";

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration.GetSection("AppSettings:Secret").Value);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Role, tur),
                }),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
        
    }
}
