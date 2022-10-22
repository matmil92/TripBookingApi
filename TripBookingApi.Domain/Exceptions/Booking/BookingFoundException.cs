namespace TripBookingApi.Domain.Exceptions.Booking
{
    public class BookingFoundException : BussinessException
    {
        public BookingFoundException() : base("email is already registered")
        {
        }
    }
}
