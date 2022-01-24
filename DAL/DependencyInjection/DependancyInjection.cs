using DAL.DataContext;
using DAL.Repos.implementation;
using DAL.Repos.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DAL.DependencyInjection
{
    public static class DependancyInjection
    {
        public static void DAL_DI(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContextPool<DatabaseContext>(option =>
            {
                option.UseSqlServer(configuration.GetConnectionString("DefaultConnection"), m => m.MigrationsAssembly("DAL"));
            });

            services.AddScoped<IEmailRepo_DAL, EmailRepo_DAL>();



        }
    }
}
