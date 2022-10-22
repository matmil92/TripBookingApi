using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public Trip(string name, Country country, string description, DateTime startDate, int numberOfSeats, List<Booking> bookings)
        {
            Name = name;
            Country = country;
            Description = description;
            StartDate = startDate;
            NumberOfSeats = numberOfSeats;
            Bookings = bookings;
        }

        [Key]
        public string Name { get; private set; }
        public Country Country { get; private set; }
        public string Description { get; private set; }
        public DateTime StartDate { get; private set; }
        public int NumberOfSeats { get; private set; }
        public List<Booking> Bookings { get; private set; }
    }
}
