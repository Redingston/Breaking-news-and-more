using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.Helpers;
using Application.Interfaces.Services;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Application.Services
{
    public class JwtService : IJwtService
    {
        private readonly JwtOptions jwtOptions;
        private readonly UserManager<User> userManager;
        private readonly IConfiguration _configuration;

        public JwtService(IOptions<JwtOptions> jwtOptions, UserManager<User> userManager,
            IConfiguration configuration)
        {
            this.userManager = userManager;
            _configuration = configuration;
            var optKey = _configuration.GetSection("JwtOptions:Key");
            var optIssuer = _configuration.GetSection("JwtOptions:Issuer");
            var optLT = _configuration.GetSection("JwtOptions:LifeTime");
            this.jwtOptions = new JwtOptions() {Issuer = optIssuer.Value, Key = optKey.Value, LifeTime = Int32.Parse(optLT.Value)};
        }

        public string CreateRefreshToken()
        {
            var randomNumber = new byte[32];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);
        }

        public string CreateToken(IEnumerable<Claim> claims)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.Key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: jwtOptions.Issuer,
                claims: claims,
                expires: DateTime.UtcNow.AddHours(jwtOptions.LifeTime),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public IEnumerable<Claim> GetClaimsFromExpiredToken(string token)
        {
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = false,
                ValidateLifetime = false,
                ValidateIssuerSigningKey = true,
                ValidIssuer = jwtOptions.Issuer,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.Key)),
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            JwtSecurityToken jwtSecurityToken;

            tokenHandler.ValidateToken(token, tokenValidationParameters, out SecurityToken securityToken);
            jwtSecurityToken = securityToken as JwtSecurityToken;

            if (jwtSecurityToken == null || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256,
                    StringComparison.InvariantCultureIgnoreCase))
                throw new HttpException(System.Net.HttpStatusCode.BadRequest, "Invalid Token");

            return jwtSecurityToken.Claims;
        }

        public IEnumerable<Claim> SetClaims(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Name, user.UserName),
            };

            var roles = userManager.GetRolesAsync(user).Result;
            claims.AddRange(roles.Select(role => new Claim(ClaimsIdentity.DefaultRoleClaimType, role)));

            return claims;
        }
    }
}