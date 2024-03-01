using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using pasaj.Service;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TOKENS = System.IdentityModel.Tokens.Jwt;

namespace pasaj.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {

        private readonly IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public IActionResult Login(UserLoginModel userLoginModel)
        {
            if (ModelState.IsValid)
            {
                var user = _userService.ValidateUser(userLoginModel.UserName, userLoginModel.Password);
                if (user != null)
                {
                    SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Bu-cümle-kritik-bir-cümledir-ona-göre"));

                    SigningCredentials signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

                    var claims = new Claim[]
                    {
                        new Claim(TOKENS.JwtRegisteredClaimNames.Name, user.Name),
                        new Claim(ClaimTypes.Role, user.Role),

                    };

                    JwtSecurityToken token = new TOKENS.JwtSecurityToken(
                        issuer: "main.turkcell",
                        audience: "client.turkcell",
                        claims: claims,
                        notBefore: DateTime.Now,
                        expires: DateTime.Now.AddDays(2),
                        signingCredentials: signingCredentials
                        );

                    return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) });




                }
                return BadRequest(new { message = "Hatalı giriş" });

            }
            return BadRequest(ModelState);

        }
    }
}
