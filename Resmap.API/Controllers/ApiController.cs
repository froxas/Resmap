using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Resmap.API.Controllers
{
    public class ApiController : Controller
    {
        [Route("api/login")]
        public IActionResult Login()
        {
            // TODO: Get users login information and check it is correct

            var username = "vaidas";
            var email = "vaidas@opit.lt";

            // Generate a token
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
                new Claim(JwtRegisteredClaimNames.NameId, "Unknownuser"),
                new Claim(JwtRegisteredClaimNames.Email, email),
                new Claim("my key", "my value"),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes())

        }
    }
}