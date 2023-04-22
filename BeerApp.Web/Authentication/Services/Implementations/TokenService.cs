using BeerApp.Dao.Models;
using BeerApp.Web.Authentication.Configuration;
using BeerApp.Web.Authentication.Services.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace BeerApp.Web.Authentication.Services.Implementations
{
    public class TokenService : ITokenService
    {
        private readonly JwtConfiguration _jwtConfiguration;
        public TokenService(JwtConfiguration jwtConfiguration)
        {
            _jwtConfiguration = jwtConfiguration ?? throw new ArgumentNullException(nameof(jwtConfiguration));
        }

        public string GenerateAccessToken(User user)
        {
            var key = _jwtConfiguration.Key;
            if (key is null)
                throw new Exception("Authorization configuration is not avaliable.");

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Username!),
                new Claim(ClaimTypes.GivenName, user.Username!),
                new Claim(ClaimTypes.Name, user.Name!),
                new Claim(ClaimTypes.Surname, user.Surname!),
                new Claim(ClaimTypes.Email, user.Email!),
            };

            var token = new JwtSecurityToken(_jwtConfiguration.Issuer,
                _jwtConfiguration.Audience,
                claims,
                expires: DateTime.Now.AddMinutes(15),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);
        }

        public ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
        {
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = false,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtConfiguration.Key!)),
                ValidIssuer = _jwtConfiguration.Issuer,
                ValidAudience = _jwtConfiguration.Audience
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken securityToken;
            var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out securityToken);
            var jwtSecurityToken = securityToken as JwtSecurityToken;
            if (jwtSecurityToken == null || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
                throw new SecurityTokenException("Invalid token");
            return principal;
        }
    }
}
