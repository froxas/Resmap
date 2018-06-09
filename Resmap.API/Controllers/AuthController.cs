using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Resmap.API.Controllers
{
    [Route("api/auth")]
    public class AuthController : Controller
    {
        [HttpPost("token")]
        public IActionResult Token()
        {
            var header = Request.Headers["Authorization"];

            if (header.ToString().StartsWith("Basic"))
            {
                var credValue = header.ToString().Substring("Basic".Length).Trim();
                var usernameAndPassword = Encoding.UTF8.GetString(Convert.FromBase64String(credValue));
                var usernameAndPass = usernameAndPassword.Split(":");

                // check in DB username and pass exist
                if (usernameAndPass[0] == "admin" && usernameAndPass[1] == "admin")
                {
                    var claimsdata = new[] { new Claim(ClaimTypes.Name, "username") };
                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("asadasfdasfsadgvasfdasdasd"));
                    var signInCred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

                    var token = new JwtSecurityToken(
                        issuer: "mysite.com",
                        audience: "mysite.com",
                        expires: DateTime.Now.AddMinutes(1),
                        claims: claimsdata,
                        signingCredentials: signInCred
                        );

                    var tokenString = new JwtSecurityTokenHandler().WriteToken(token);
                    return Ok(tokenString);
                }

            }

            return BadRequest("Wrong request");
                     
        }
    }
}