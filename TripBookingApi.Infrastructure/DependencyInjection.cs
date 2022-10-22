using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TripBookingApi.Application.Interfaces;
using TripBookingApi.Infrastructure.DbContexts;

namespace TripBookingApi.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var dbName = configuration["DbName"];
            services.AddDbContext<IDbContext, InMemoryDbContext>(opt => opt.UseInMemoryDatabase(dbName));
            return services;
        }
    }
}
