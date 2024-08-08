using BaseProject.Application.Interfaces.Repositories;
using BaseProject.Infrastructure.Contexts;
using BaseProject.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BaseProject.Infrastructure
{
    public class ServiceRegistration
    {
        public static void Configure(IServiceCollection service, IConfiguration configuration)
        {
            service.AddScoped<IUserRepositoriesAsync, UserRepository>();


            var connectionString = configuration.GetConnectionString("DefaultConnection");
            service.AddDbContext<ApplicationDbContext>(options =>
                           options.UseSqlServer(connectionString));
        }
    }
}
