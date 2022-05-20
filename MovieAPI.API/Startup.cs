using System.Text;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using MovieAPI.DataTier.Concrete;
using MovieAPI.DataTier.Context;
using MovieAPI.DataTier.Interfaces;
using MovieAPI.ServiceTier.AutoMapper.Profiles;
using MovieAPI.ServiceTier.Concrete;
using MovieAPI.ServiceTier.Extension;
using MovieAPI.ServiceTier.Filters;
using MovieAPI.ServiceTier.Interfaces;
using MovieAPI.ServiceTier.JWT;
using MovieAPI.ServiceTier.JWT.Concrete;
using MovieAPI.ServiceTier.JWT.Interface;
using MovieAPI.ServiceTier.Validators.Managers;
using MovieAPI.ServiceTier.Validators.Movies;

namespace MovieAPI.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.MyService();
            #region Jwt
            var key = Encoding.ASCII.GetBytes(Configuration["Secret"]);
            services.AddAuthentication(a =>
            {
                a.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                a.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(b =>
            {
                b.RequireHttpsMetadata = false;//http
                b.SaveToken = true;
                b.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuerSigningKey = true,//token deðerinin bu uygulamaya ait olup olmadýgýný anlamamýzý saðlayan security key doðrulamasý aktiflestirildi.
                    IssuerSigningKey = new SymmetricSecurityKey(key),//olusturulan token deðerinin uygulamaya ait deðer oldugnu belirten security key
                    ValidateIssuer = false,//olusturulan token deðerini kimin daðýttýðýný belirten alan 
                    ValidateAudience = true,//olusturulan token deðerini kimlerin belirlediði hangi sitelerin kullanacagýný belirten alan
                };
            });

            #endregion
            services.AddAutoMapper(typeof(MovieProfile), typeof(UserProfile));
            services.AddPersistenceServices();
            services.AddControllers(opt => opt.Filters.Add<ValidationFilter>())
                .AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<SaveManagerValidator>())
                .AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<SaveMovieValidator>())
                .ConfigureApiBehaviorOptions(options => options.SuppressModelStateInvalidFilter = true);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MovieAPI.API", Version = "v1" });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MovieAPI.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
