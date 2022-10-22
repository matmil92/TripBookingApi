using Microsoft.EntityFrameworkCore;
using TripBookingApi.Domain.Entities;

namespace TripBookingApi.Application.Interfaces
{
    public interface IDbContext
    {
        public DbSet<Trip> Trips { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Booking> Bookings { get; set; }
    }
}
