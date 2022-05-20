
using Microsoft.Extensions.DependencyInjection;
using MovieAPI.DataTier.Concrete;
using MovieAPI.DataTier.Interfaces;
using MovieAPI.ServiceTier.Concrete;
using MovieAPI.ServiceTier.Interfaces;
using MovieAPI.ServiceTier.JWT.Concrete;
using MovieAPI.ServiceTier.JWT.Interface;

namespace MovieAPI.ServiceTier.Extension
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection MyService(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IMovieRepository, MovieRepository>();
            serviceCollection.AddScoped<IMovieService, MovieService>();
            serviceCollection.AddScoped<IManagerRepository, ManagerRepository>();
            serviceCollection.AddScoped<IManagerService, ManagerService>();
            serviceCollection.AddScoped<ICategoryService, CategoryService>();
            serviceCollection.AddScoped<ICategoryRepository, CategoryRepository>();
            serviceCollection.AddScoped<IUserService, UserService>();
            serviceCollection.AddScoped<IUserRepository, UserRepository>();
            serviceCollection.AddScoped<IActorService, ActorService>();
            serviceCollection.AddScoped<IActorRepository, ActorRepository>();
            serviceCollection.AddScoped<ITokenService, TokenService>();



            return serviceCollection;
        }


    }
}
