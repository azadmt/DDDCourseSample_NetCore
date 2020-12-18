using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IdentityServer.Infrastructure;
using IdentityServer.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace IdentityServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SecurityController : ControllerBase
    {
        private IConfiguration _config;

        public SecurityController(IConfiguration config)
        {
            _config = config;
        }

        [HttpPost]
        public IActionResult Login(Model.LoginModel loginModel)
        {
            string token = string.Empty;
            //authenticate 

            if (InMemoryDB.Users.Any(p => p.Username == loginModel.Username && p.Password == loginModel.Password))
            {
                token = Guid.NewGuid().ToString();
                InMemoryDB.Tokens.Add
                    (token,
                    new IdentityServer.Model.SecurityToken()
                    {
                        Roles = InMemoryDB.UserPermissions[loginModel.Username],
                        Username = loginModel.Username

                    });
            }
            return Ok(new { Token = token });
        }

        [HttpGet]
        public Model.SecurityToken Get(string token)
        {
            var permission = InMemoryDB.Tokens[token];
            return permission;
        }


        private string GenerateJSONWebToken(UserModel userInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Issuer"],
              null,
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private UserModel AuthenticateUser(LoginModel login)
        {
            UserModel user = null;
            //TODO: Read From DB
            if (login.Username == "myUserName")
            {
                user = new UserModel { Username = "myUserName", EmailAddress = "myUserName@gmail.com" };
            }
            return user;
        }
    }
}