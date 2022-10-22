using System.ComponentModel.DataAnnotations;

namespace TripBookingApi.Domain.Entities
{
    public class Trip
    {
        public Trip()
        {
            Name = "";
            Country = new Country();
            Description = "";
            StartDate = DateTime.MinValue;
            NumberOfSeats = 0;
            Bookings = new List<Booking>();
        }

        public Trip(string name, Country country, string description, DateTime startDate, int numberOfSeats)
        {
            Name = name;
            Country = country;
            Description = description;
            StartDate = startDate;
            NumberOfSeats = numberOfSeats;
            Bookings = new List<Booking>();
        }

        [Key]
        [MaxLength(200)]
        public string Name { get; private set; }
        public Country Country { get; private set; }
        [MaxLength(4000)]
        public string Description { get; private set; }
        public DateTime StartDate { get; private set; }
        public int NumberOfSeats { get; private set; }
        public List<Booking> Bookings { get; private set; }
    }
}
