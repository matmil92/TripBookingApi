using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TripBookingApi.Domain.Entities
{
    public class Booking
    {
        public Booking()
        {
            Trip = new Trip();
            Email = "";
        }

        public Booking(Trip trip, string email)
        {
            Trip = trip;
            Email = email;
        }

        [Key]
        [Column(Order = 1)]
        public Trip Trip { get; set; }
        [Key]
        [Column(Order = 2)]
        [MaxLength(200)]
        public string Email { get; set; }
    }
}
