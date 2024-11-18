using Microsoft.Extensions.DependencyInjection;

using UnitOfWork.BusinessLogicLayer.Services;
using UnitOfWork.Contracts.Services;

namespace UnitOfWork.BusinessLogicLayer.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddBusinessLogicLayer(this IServiceCollection services)
        {
            services.AddScoped<IMovieService, MovieService>();
        }
    }
}
