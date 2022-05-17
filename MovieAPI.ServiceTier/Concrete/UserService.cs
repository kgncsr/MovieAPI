using System.Collections.Generic;
using AutoMapper;
using MovieAPI.DataTier.Interfaces;
using MovieAPI.ModelTier;
using MovieAPI.ServiceTier.Interfaces;
using MovieAPI.ServiceTier.Responses;
using System.Threading.Tasks;
using MovieAPI.ServiceTier.Dtos.User;
using System.Linq;

namespace MovieAPI.ServiceTier.Concrete
{
    public class UserService : IUserService
    {
        private readonly IUserRepository m_userRepository;
        private readonly IMapper m_mapper;

        public UserService(IUserRepository userRepository,IMapper mapper)
        {
            m_mapper=mapper;
            m_userRepository = userRepository;
        }
        public async Task<DataResponse<UserDto>> GetUserByIdAsync(int id, bool track = true)
        {
            var user = await m_userRepository.GetByIdAsync(id,track);
            if (user==null)
            {
                return new DataResponse<UserDto>(false, "Böyle bir kullanıcı yok", null);
            }
            var userDto = m_mapper.Map<UserDto>(user); 

            return new DataResponse<UserDto>(true, userDto);
            
        }

        public async Task<DataResponse<UserDto>> GetUserByUserName(string userName, bool track = true)
        {
            var user = await m_userRepository.GetSingleFilterAsync(a => a.UserName.Contains(userName), track);
            var userDto = m_mapper.Map<UserDto>(user);
            return new DataResponse<UserDto>(true,userDto);
        }

        public async Task<DataResponse<IQueryable<UserDto>>> AllUser()
        {
            var users =await m_userRepository.GetAllAsync(false);
            var usersdto = users.Select(a => m_mapper.Map<UserDto>(a));

            return new DataResponse<IQueryable<UserDto>>(true, usersdto);
        }
    }
}
