namespace TripBookingApi.Domain.Exceptions.Booking
{
    public class BookingNotFoundException : BussinessException
    {
        public BookingNotFoundException() : base("booking not found")
        {
        }
    }
}
