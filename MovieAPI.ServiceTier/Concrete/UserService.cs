using System;
using System.Collections.Generic;
using AutoMapper;
using MovieAPI.DataTier.Interfaces;
using MovieAPI.ModelTier;
using MovieAPI.ServiceTier.Interfaces;
using MovieAPI.ServiceTier.Responses;
using System.Threading.Tasks;
using MovieAPI.ServiceTier.Dtos.User;
using System.Linq;
using System.Linq.Expressions;
using MovieAPI.ServiceTier.JWT.Interface;

namespace MovieAPI.ServiceTier.Concrete
{
    public class UserService : IUserService
    {
        private readonly IUserRepository m_userRepository;
        private readonly IMapper m_mapper;
        private readonly  ITokenService m_tokenService;
        public UserService(IUserRepository userRepository, IMapper mapper, ITokenService mTokenService)
        {
            m_mapper = mapper;
            m_tokenService = mTokenService;
            m_userRepository = userRepository;
        }
        public async Task<DataResponse<UserDto>> GetUserByIdAsync(int id, bool track = true)
        {
            var user = await m_userRepository.GetByIdAsync(id, track);
            if (user == null)
            {
                return new DataResponse<UserDto>(false, "Böyle bir kullanıcı yok", null);
            }
            var userDto = m_mapper.Map<UserDto>(user);

            return new DataResponse<UserDto>(true, userDto);

        }

        public async Task<DataResponse<UserDto>> GetUserByName(string userName, bool track = true)
        {
            var user = await m_userRepository.GetSingleFilterAsync(a => a.UserName.Contains(userName), track);
            var userDto = m_mapper.Map<UserDto>(user);
            return new DataResponse<UserDto>(true, userDto);
        }

        public async Task<DataResponse<UserDto>> GetUserAsync(Expression<Func<User, bool>> filter)
        {
            var user = await m_userRepository.GetSingleFilterAsync(filter);
            if (!user.Equals(null))
            {
                var userDto = m_mapper.Map<UserDto>(user);
                return new DataResponse<UserDto>(true, userDto);
            }

            return new DataResponse<UserDto>(false, null);
        }

        public async Task<DataResponse<IQueryable<UserDto>>> AllUser()
        {
            var users = await m_userRepository.GetAllAsync(false);
            var usersdto = users.Select(a => m_mapper.Map<UserDto>(a));

            return new DataResponse<IQueryable<UserDto>>(true, usersdto);
        }



        public async Task<User> AddAsync(UserAddTestDto userDto)
        {
            var news = m_mapper.Map<UserDto>(userDto);
            var token  = m_tokenService.CreateToken(userDto.UserName, userDto.Email);
            news.Token = token.Token;
            news.TokenExpireDate = token.TokenExpirition;
            var news2 = m_mapper.Map<User>(news);
            await m_userRepository.AddAsync(news2);

            return news2;
        }

        //public Task<DataResponse<UserUpdateDto>> Update(UserUpdateDto userUpdate)
        //{
        //    var user = GetUserAsync(a=>a.Id==userUpdate.Id);
        //    var newuserdto = 
        //}
    }
}
