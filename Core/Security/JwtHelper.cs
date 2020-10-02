using Core.Entities.Concrete;
using IdentityModel;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Core.Security
{
    public class JwtHelper
    {
        private readonly IConfiguration _configuration;
        private JWTTokenOptions _tokenOptions;
        private DateTime _tokenExpiration;

        public JwtHelper(IConfiguration configuration)
        {
            _configuration = configuration;
            _tokenOptions = configuration.GetSection("TokenOptions").Get<JWTTokenOptions>();
            _tokenExpiration = DateTime.Now.AddDays(_tokenOptions.ExpirationInDays);
        }

        public AccessToken CreateToken(ApplicationUser user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_tokenOptions.SecurityKey));
            var signInCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
            var jwt = GenerateJwtSecurityToken(_tokenOptions, user, signInCredentials);
            var token = new JwtSecurityTokenHandler().WriteToken(jwt);

            return new AccessToken { Token = token, Expiration = _tokenExpiration };
        }

        private JwtSecurityToken GenerateJwtSecurityToken(JWTTokenOptions tokenOptions, ApplicationUser user, SigningCredentials signInCredentials)
        {
            var jwt = new JwtSecurityToken(
                issuer: tokenOptions.Issuer,
                audience: tokenOptions.Audience,
                notBefore: DateTime.Now,
                expires: _tokenExpiration,
                signingCredentials: signInCredentials,
                claims: SetClaims(user));

            return jwt;
        }

        private IEnumerable<Claim> SetClaims(ApplicationUser user)
        {
            return new List<Claim>
            {
                new Claim("userId", user.Id),
                new Claim(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtClaimTypes.Role, user.RoleName),
                new Claim("fullname", user.FullName)
            };
        }
    }
}
