using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MovieAPI.ServiceTier.JWT.Interface;

namespace MovieAPI.ServiceTier.JWT.Concrete
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration m_configuration;
        public TokenService(IConfiguration mConfiguration)
        {
            m_configuration = mConfiguration;
          
        }
        public AccessToken CreateToken(/*int userId,*/ string userName,string eMail)
        {
            byte[] key = Encoding.ASCII.GetBytes(m_configuration["Secret"]/*m_appSettings.Secret*/);
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, userName),
                    new Claim(ClaimTypes.Email, eMail),
                    //new Claim(ClaimTypes.NameIdentifier, userId.ToString()),
                }),
                Expires = DateTime.UtcNow.AddDays(5),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            var accessToken = new AccessToken()
            {
                Token = tokenHandler.WriteToken(token),
                TokenExpirition = (DateTime)tokenDescriptor.Expires,
            };
            return accessToken;

        }
    }
}
