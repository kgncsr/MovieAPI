using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MovieAPI.ServiceTier.JWT.Interface;

namespace MovieAPI.ServiceTier.JWT.Concrete
{
    public class TokenService : ITokenService
    {
        private  readonly  AppSettings m_appSettings;
        public TokenService(IOptions<AppSettings> appSettings)
        {
            m_appSettings = appSettings.Value;
        }
        public AccessToken CreateToken(int userId, string userName,string eMail)
        {
            byte[] key = Encoding.UTF8.GetBytes(m_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, userName.ToString()),
                    new Claim(ClaimTypes.Email, eMail.ToString()),
                    new Claim(ClaimTypes.NameIdentifier, userId.ToString()),
                }),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            var accessToken = new AccessToken()
            {
                UserId = userId,
                UserName = userName,
                EMail = eMail,
                Token = tokenHandler.WriteToken(token),
                TokenExpirition = (DateTime)tokenDescriptor.Expires,
            };
            return accessToken;

        }
    }
}
