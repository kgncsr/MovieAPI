using MovieAPI.ServiceTier.Dtos.User;
using MovieAPI.ServiceTier.JWT;
using MovieAPI.ServiceTier.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieAPI.ServiceTier.Interfaces
{
    public interface IAuthService  
    {
        Task<DataResponse<AccessToken>> LoginAsync(UserLoginDto userLoginDto);
    }
}
