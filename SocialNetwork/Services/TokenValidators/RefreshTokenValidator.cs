using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System;
using Microsoft.Extensions.Configuration;
using SocialNetwork.Models.DTOs.Responses;

namespace SocialNetwork.Services.TokenValidators
{
    public class RefreshTokenValidator
    {
        private readonly IConfiguration _configuration;
        public RefreshTokenValidator(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public RefreshTokenResponse Validate(string refreshToken)
        {
            // 1. Create parameter to valid refresh token
            TokenValidationParameters validationParameters = new TokenValidationParameters()
            {
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["AuthSettings:RefreshTokenSecret"])),
                ValidIssuer = _configuration["AuthSettings:Issuer"],
                ValidAudience = _configuration["AuthSettings:Audience"],
                ValidateIssuerSigningKey = true,
                ValidateIssuer = true,
                ValidateAudience = true,
                ClockSkew = TimeSpan.Zero
            };

            // 2. Check if valid refresh token
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();

            try
            {
                tokenHandler.ValidateToken(refreshToken, validationParameters, out SecurityToken validatedToken);
            }
            catch
            {
                return new RefreshTokenResponse
                {
                    IsSuccess = false,
                    ErrorMessage = "Refresh Token không hợp lệ !",
                };
            }

            return new RefreshTokenResponse
            {
                IsSuccess = true,
            };
        }
    }
}
