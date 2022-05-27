using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APITalyCapGlobal.Entities;
using APITalyCapGlobal.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

namespace APITalyCapGlobal.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ApiDBContext _context;
        private readonly Jwt _setting;

        public UsersController(ApiDBContext context,IOptions<Jwt> options)
        {
            _context = context;
            _setting = options.Value;
        }

        // GET: api/Users/5
        [AllowAnonymous]
        [HttpPost("/login")]
        public ActionResult GetLogin(Users user)
        {
            var data = _context.Users.FirstOrDefault(x => x.userName == user.userName && x.password == user.password);
            if (data == null)
            {
                return NotFound();
            }

            // generate token that is valid for 7 minutes
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.ASCII.GetBytes(_setting.SecretKey);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", data.userName.ToString()) }),
                Expires = DateTime.UtcNow.AddMinutes(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return Ok(new { token = tokenHandler.WriteToken(token), UserName = data.userName.ToString(), Message = "Success" }); ;
        }
        
    }
}
