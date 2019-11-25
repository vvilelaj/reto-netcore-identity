using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using reto_bcp_api.Dtos.Auth;
using reto_bcp_api.Persistance.Models;
using reto_bcp_api.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace reto_bcp_api.Services
{
    /// <summary>
    /// 
    /// </summary>
    public class AuthService : IAuthService

    {
        private readonly UserManager<RetoBcpUser> _userManager;
        private readonly SignInManager<RetoBcpUser> _signInManager;
        private readonly IConfiguration _configuration;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="userManager"></param>
        /// <param name="signInManager"></param>
        /// <param name="configuration"></param>
        public AuthService(UserManager<RetoBcpUser> userManager, SignInManager<RetoBcpUser> signInManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="loginDto"></param>
        public string Login(LoginDto loginDto)
        {

            var user = _userManager.FindByNameAsync(loginDto.Usuario).Result;
            if (user == null)
                throw new ApplicationException($"AuthService.Login : usuario {loginDto.Usuario} no existe.");

            var result = _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false).Result;
            if (!result.Succeeded)
                throw new ApplicationException($"AuthService.Login : usuario {loginDto.Usuario} no puede loguearse.");

            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id));
            claims.Add(new Claim(ClaimTypes.Name, user.UserName));
            if (_userManager.IsInRoleAsync(user, "Admin").Result)
            {
                claims.Add(new Claim(ClaimTypes.Role, "Admin"));
            }
            if (_userManager.IsInRoleAsync(user, "ApiUser").Result)
            {
                claims.Add(new Claim(ClaimTypes.Role, "ApiUser"));
            }

            var secretKey = _configuration.GetValue<string>("SecretKey");
            var key = Encoding.ASCII.GetBytes(secretKey);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var strToken = tokenHandler.WriteToken(token);

            return strToken;
        }
    }

}

