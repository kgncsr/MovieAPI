using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieAPI.ModelTier;
using MovieAPI.ServiceTier.Dtos.User;
using MovieAPI.ServiceTier.JWT;
using MovieAPI.ServiceTier.Responses;

namespace MovieAPI.ServiceTier.Interfaces
{
    public interface IUserService
    {
        Task<DataResponse<UserDto>> GetUserByIdAsync(int id, bool track = true);
        Task<DataResponse<UserDto>> GetUserByUserName(string userName, bool track = true);
        Task<DataResponse<IQueryable<UserDto>>> AllUser();


    }
}
