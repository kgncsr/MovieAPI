using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MovieAPI.DataTier.Interfaces;
using MovieAPI.ServiceTier.Dtos.User;
using MovieAPI.ServiceTier.Interfaces;
using MovieAPI.ServiceTier.JWT;

namespace MovieAPI.ServiceTier.Concrete
{
    public class UserService : IUserService
    {
        private readonly IUserRepository m_userRepository;
        private readonly AppSettings m_appSettings;

        public UserService(IUserRepository userRepository, IOptions<AppSettings> appSettings)
        {
            m_appSettings = appSettings.Value;
            m_userRepository = userRepository;
        }

        public async Task<AccessToken> Authanticate(UserLoginDto userLogin)
        {
            var user = await m_userRepository.GetSingleFilterAsync(a =>
                a.UserName == userLogin.UserName && a.Password == userLogin.Password);

            if (user==null)
            {
                return null;
            }
            byte[] key = Encoding.ASCII.GetBytes(m_appSettings.SecurityKey); //byte a ceviriyorum key'i
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
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
                Expirition = (DateTime)tokenDescriptor.Expires,
                UserId = user.Id,
                UserName = user.UserName
            };
            return await Task.Run(() => accessToken);
        }
    }
}