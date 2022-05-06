using AutoMapper;
using MovieAPI.DataTier.Interfaces;
using MovieAPI.Entities;
using MovieAPI.ServiceTier.Dtos.Movie;
using MovieAPI.ServiceTier.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MovieAPI.ServiceTier.Concrete
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository m_movieRepository;
        private readonly IMapper m_mapper;
        public MovieService(IMovieRepository movieRepository, IMapper mapper)
        {
            m_mapper = mapper;
            m_movieRepository = movieRepository;
        }

        public Task<bool> AddAsync(MovieCreateDto model)
        {

            var result = m_movieRepository.AddAsync(m_mapper.Map<Movie>(model));
            return result;
        }
        public Task<bool> AddRangeAsync(IEnumerable<Movie> adds)
        {
            return m_movieRepository.AddRangeAsync(adds);
        }
        public bool Delete(Movie model)
        {
            return m_movieRepository.Delete(model);
        }
        public bool DeleteById(int id)
        {
            return m_movieRepository.DeleteByIdAsync(id);
        }
        public async Task<List<MovieDto>> FindByYearAsync(int year, bool track = true)
        {
            var result =  await m_movieRepository.FindByYear(year, track);
            var movies =  result.Select(movie => m_mapper.Map<MovieDto>(movie)).ToList();
            return movies;
        }
        public async Task<IEnumerable<MovieDto>> FindMoviesYearMonth(int year, int month, bool track = true)
        {
            var result = await m_movieRepository.FindMoviesYearMonth(year, month, track);
            var movies = result.Select(a => m_mapper.Map<MovieDto>(a)).ToList();
            return movies;
        }
        public async Task<IQueryable<MovieDto>> GetAllAsync(bool track = true)
        {
            var result = await m_movieRepository.GetAllAsync(track);
            var movies = result.Select(a => m_mapper.Map<MovieDto>(a)).AsQueryable();

            return movies;

        }
        public async Task<IEnumerable<MovieManagerDto>> FindMoviesByManagerId(int managerId, bool track = true)
        {
            var result = await m_movieRepository.FindMoviesByManagerId(managerId, track);
            var all = result.Select(a => m_mapper.Map<MovieManagerDto>(a)).AsEnumerable();
            return all;

        }
        public async Task<long> GetCountAsync()
        {
            return await m_movieRepository.GetCountAsync();
        }
        public async Task<MovieDto> GetByIdAsync(int id, bool track = true)
        {

            var result =await m_movieRepository.GetByIdAsync(id, track);
            var movie = m_mapper.Map<MovieDto>(result);
            return movie;
        }
        public bool DeleteRange(IEnumerable<Movie> deletes)
        {
            throw new NotImplementedException();
        }
        public bool Update(MovieUpdateDto movieUpdateDto)
        {
            return m_movieRepository.Update(m_mapper.Map<Movie>(movieUpdateDto));
        }
        public Task<decimal> FindSumYearAsync(int year)
        {
            return m_movieRepository.FindSumYearAsync(year);
        }
        public async Task<List<MovieDto>> MoviesByImdbGreaterOrderBy(long imdb, bool track = true)
        {
            var result =await m_movieRepository.MoviesByImdbGreaterOrderBy(imdb, track);
            var movies = result.Select(movie => m_mapper.Map<MovieDto>(result)).ToList();
            return movies;
        }

    }
}
