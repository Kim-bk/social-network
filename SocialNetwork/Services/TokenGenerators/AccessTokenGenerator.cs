using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System;
using Microsoft.Extensions.Configuration;
using SocialNetwork.Models;

namespace SocialNetwork.Services.TokenGenerators
{
    public class AccessTokenGenerator
    {
        private readonly IConfiguration _configuration;
        private readonly TokenGenerator _tokenGenerator;
        public AccessTokenGenerator(IConfiguration configuration, TokenGenerator tokenGenerator)
        {
            _configuration = configuration;
            _tokenGenerator = tokenGenerator;
        }

        public JwtSecurityToken Generate(User user, string listCredentials)
        {
            var claims = new[]
            {
                new Claim("Email", user.Email),
                new Claim("Credentials", listCredentials),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["AuthSettings:AccessTokenSecret"]));
            var issuer = _configuration["AuthSettings:Issuer"];
            var audience = _configuration["AuthSettings:Audience"];
            var expires = DateTime.UtcNow.AddMinutes(1); // expires in 1 minutes later
            var token = _tokenGenerator.GenerateToken(key, issuer, audience, expires, claims);
            return token;
        }
    }
}
