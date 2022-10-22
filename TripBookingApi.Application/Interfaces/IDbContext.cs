using Microsoft.EntityFrameworkCore;
using TripBookingApi.Domain.Entities;

namespace TripBookingApi.Application.Interfaces
{
    public interface IDbContext
    {
        DbSet<Trip> Trips { get; set; }
        DbSet<Country> Countries { get; set; }
        DbSet<Booking> Bookings { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
        void SeedData();
    }
}
