using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using UnitOfWork.Contracts.Contracts;
using UnitOfWork.DataAccessLayer.Contexts;
using UnitOfWork.DataAccessLayer.Repository;

namespace UnitOfWork.DataAccessLayer.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddDataAccessLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseMySQL(configuration.GetConnectionString("UnitOfWorkDb")!), ServiceLifetime.Transient);

            services.AddTransient<DbContext, ApplicationDbContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork.UnitOfWork>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        }
    }
}
