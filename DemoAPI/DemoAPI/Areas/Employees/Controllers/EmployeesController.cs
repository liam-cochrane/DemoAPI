using DemoAPI.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
//using Domain.Areas.Employees.Managers;
//using Domain.Areas.Employees.Models;

namespace DemoAPI.Areas.Employees.Controllers
{

    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class EmployeesController : ControllerBase
    {
        private readonly ILogger<EmployeesController> _logger;
        //private readonly CompaniesManager manager;
        private readonly AppSettings _appSettings;

        public EmployeesController(ILogger<EmployeesController> logger, IOptions<AppSettings> appSettings)
        {
            _logger = logger;
            //manager = new CompaniesManager();
            _appSettings = appSettings.Value;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("Authenticate")]
        public ActionResult Authenticate()
        {
            var employee = new { Id = 123456 };

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, employee.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            return Ok(tokenString);
        }
    }
}
