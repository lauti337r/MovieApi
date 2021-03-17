using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using MovieApi.Models;
using MovieApi.Services.Interfaces;
using MovieApi.Utils;
using JwtRegisteredClaimNames = System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames;

namespace MovieApi.Controllers
{
    public class UserController : BaseController
    {
        private IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [AllowAnonymous]
        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] AuthRequest credentials)
        {
            if (_userService.ValidateUserCredentials(credentials.Username, credentials.Password))
            {
                Claim[] claims = {
                    new Claim(JwtRegisteredClaimNames.Sub, credentials.Username)
                };

                byte[] secretBytes = Encoding.UTF8.GetBytes(Constants.Secret);
                SymmetricSecurityKey key = new SymmetricSecurityKey(secretBytes);

                SigningCredentials signingCrendentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                JwtSecurityToken token = new JwtSecurityToken(Constants.Issuer, Constants.Audience, claims, DateTime.Now, DateTime.Now.AddHours(1), signingCrendentials);

                string tokenJson = new JwtSecurityTokenHandler().WriteToken(token);

                return Ok(new {access_token = tokenJson });
            }

            return Unauthorized();
        }
    }
}
