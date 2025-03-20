using Deliver.API.Models;
using Deliver.Core.DTOs;
using Deliver.Core.Models;
using Deliver.Core.Repositories;
using Deliver.Data.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Deliver.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IDeliveryRepository _deliveryRepository;
        public AuthController(IConfiguration configuration, IDeliveryRepository deliveryRepository)
        {
            _configuration = configuration;
            _deliveryRepository = deliveryRepository;

        }
        [HttpPost]
        public IActionResult Login([FromBody] DeliveryDto loginModel)
        {
            var delivery = _deliveryRepository.GetDeliveryByName(loginModel.Name);

            if (delivery == null)
            {
                return Unauthorized("שם משתמש או סיסמה שגויים");
            }

            bool passwordMatch = BCrypt.Net.BCrypt.Verify(loginModel.Password, delivery.Password);

            if (!passwordMatch)
            {
                return Unauthorized("שם משתמש או סיסמה שגויים");
            }
            var claims = new List<Claim>()
            {
                    new Claim(ClaimTypes.Name,"string"),
                    new Claim(ClaimTypes.Role, delivery.Roles),
                    new Claim("deliveryId", delivery.Id.ToString())
            };
            var secretKey = new
            SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetValue<string>("JWT:Key")));
            var signinCredentials = new SigningCredentials(secretKey,
            SecurityAlgorithms.HmacSha256);
            var tokeOptions = new JwtSecurityToken(
            issuer: _configuration.GetValue<string>("JWT:Issuer"),
            audience: _configuration.GetValue<string>("JWT:Audience"),
            claims: claims,
            expires: DateTime.Now.AddMinutes(6),
            signingCredentials: signinCredentials
);
            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
            var shortDelivery = new DeliveryShortDTO(delivery);

            return Ok(new { Token = tokenString, DeliveryId = delivery.Id, ShortDelivery = shortDelivery });
            }
}
}
