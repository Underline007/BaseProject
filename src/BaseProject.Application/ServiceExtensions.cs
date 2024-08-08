using BaseProject.Application.Interfaces.Services;
using BaseProject.Application.Mappings;
using BaseProject.Application.Models.DTOs.Accounts.Requests;
using BaseProject.Application.Services;
using BaseProject.Application.Validations.Accounts;
using BaseProject.Domain.Common.Settings;
using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;
namespace BaseProject.Application
{
    public class ServiceExtensions
    {
        public static void ConfigureServices(IServiceCollection service, IConfiguration configuration)
        {
            //validation
            service.AddScoped<IValidator<ChangePasswordRequest>, PasswordValidation>();



            // Dependence Injection
            service.AddScoped<ITokenService, TokenService>();
            service.AddScoped<IAccountServices, AccountService>();
            service.AddAutoMapper(typeof(GeneralProfile));


            //JWT configuration 
            var jwtSettings = service.Configure<JWTSettings>(configuration.GetSection("JWTSettings"));
            service.AddSingleton(jwtSettings);
            service.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(o =>
                {
                    o.RequireHttpsMetadata = false;
                    o.SaveToken = true;
                    o.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidIssuer = configuration["JWTSettings:Issuer"],
                        ValidAudience = configuration["JWTSettings:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWTSettings:Key"]))
                    };
                });
        }
    }
}
