using Microsoft.EntityFrameworkCore;
using TripBookingApi.Application.Interfaces;
using TripBookingApi.Domain.Entities;

namespace TripBookingApi.Infrastructure.DbContexts
{
    public class InMemoryDbContext : DbContext, IDbContext
    {
        public InMemoryDbContext(DbContextOptions<InMemoryDbContext> options) : base(options)
        {

        }
        
        public void SeedData()
        {
            Countries.AddRange(
                new Country(1, "Poland"),
                new Country(2, "Ukraine"),
                new Country(3, "France"),
                new Country(4, "Spain"),
                new Country(5, "Portugal"),
                new Country(6, "Italy"),
                new Country(7, "Greece"),
                new Country(8, "Belgium"),
                new Country(9, "United Kingdom"),
                new Country(10, "Denmark"),
                new Country(11, "Germany"),
                new Country(12, "Norway"),
                new Country(13, "Finland"),
                new Country(14, "Sweden"),
                new Country(15, "United States")
                );
            this.SaveChanges();
        }

        public DbSet<Trip> Trips { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Booking> Bookings { get; set; }
    }
}
