using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
        Task<DataResponse<UserDto>> GetUserByName(string userName, bool track = true);
        Task<DataResponse<UserDto>> GetUserAsync(Expression<Func<User, bool>> filter);
        Task<DataResponse<IQueryable<UserDto>>> AllUser();
        //Task<DataResponse<UserUpdateDto>> Update();
        Task<User> AddAsync(UserAddTestDto userAddDto);

    }
}
