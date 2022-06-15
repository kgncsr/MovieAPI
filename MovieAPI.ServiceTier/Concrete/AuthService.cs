using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using MovieAPI.DataTier.Interfaces;
using MovieAPI.ServiceTier.Dtos.User;
using MovieAPI.ServiceTier.Interfaces;
using MovieAPI.ServiceTier.JWT;
using MovieAPI.ServiceTier.JWT.Interface;
using MovieAPI.ServiceTier.Responses;

namespace MovieAPI.ServiceTier.Concrete
{
    public class AuthService : IAuthService
    {
        private readonly IUserService m_userService;
        private readonly IUserRepository m_userRepository;
        private readonly ITokenService m_tokenService;
        public AuthService(IUserService UserService, IUserRepository mUserRepository, ITokenService mTokenService)
        {
            m_userService = UserService;
            m_userRepository = mUserRepository;
            m_tokenService = mTokenService;
        }
        public async Task<DataResponse<AccessToken>> LoginAsync(UserLoginDto userLoginDto)
        {
            var user = await m_userService.GetUserAsync(a => a.UserName == userLoginDto.UserName && a.Password==userLoginDto.Password);
            if (user.Equals(null))
            {
                throw new Exception();
            }
            else
            {
                if (user.Data.TokenExpireDate == null || String.IsNullOrEmpty(user.Data.Token))
                {
                    var mytoken = m_tokenService.CreateToken(/*user.Data.Id,*/ user.Data.UserName, user.Data.Email);
                    
                    
                    
                    return new DataResponse<AccessToken>(true, "Başarılı Giriş", mytoken);
                }
            }

            return null;
        }
        //public async Task<UserRegisterDto> RegisterAsync(UserRegisterDto user)
        //{
        //    if ()
        //    {

        //    }   
        //}
    }
}
