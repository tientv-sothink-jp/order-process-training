using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using OrderManagementSystem.API.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace OrderManagementSystem.API.Services
{
    public interface ICustomAuthenticationService
    {
        string GenerateRefreshToken();
        string GenerateToken(List<Claim> claims);
        ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
    }
    public class CustomAuthenticationService : ICustomAuthenticationService
    {
        protected readonly IConfiguration _configuration;
        public CustomAuthenticationService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                return Convert.ToBase64String(randomNumber);
            }
        }

        public string GenerateToken(List<Claim> claims)
        {
            try
            {
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Secret").Value));
                var signingCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

                var tokenOptions = new JwtSecurityToken(
                    issuer: _configuration.GetSection("AppSettings:Issuer").Value,
                    audience: _configuration.GetSection("AppSettings:Audience").Value,
                    claims: claims,
                    expires: DateTime.Now.AddHours(int.Parse(_configuration.GetSection("AppSettings:Expires").Value)),
                    signingCredentials: signingCredentials
                );
                return new JwtSecurityTokenHandler().WriteToken(tokenOptions);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
        {
            var tokenValidationParameters = new TokenValidationParameters()
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ClockSkew = TimeSpan.Zero,

                ValidIssuer = _configuration.GetSection("AppSettings:Issuer").Value,
                ValidAudience = _configuration.GetSection("AppSettings:Audience").Value,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Secret").Value))
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out SecurityToken securityToken);
            var jwtSecurityToken = securityToken as JwtSecurityToken;

            if(jwtSecurityToken == null || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
            {
                throw new SecurityTokenException("Invalid token");
            }
            return principal;
        }
    }
}
