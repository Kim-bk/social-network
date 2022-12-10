using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System;

namespace SocialNetwork.Services.TokenGenerators
{
    public class TokenGenerator
    {
        public JwtSecurityToken GenerateToken(SymmetricSecurityKey secretKey, string issuer, string audience,
                         DateTime utcExpirationTime, IEnumerable<Claim> claims = null)
        {
            SigningCredentials credentials = new(secretKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                    issuer,
                    audience,
                    claims,
                    DateTime.UtcNow,
                    utcExpirationTime,
                    credentials);
            return token;
        }
    }
}
