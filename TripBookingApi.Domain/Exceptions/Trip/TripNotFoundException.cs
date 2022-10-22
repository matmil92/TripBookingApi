namespace TripBookingApi.Domain.Exceptions.Trip
{
    public class TripNotFoundException : BussinessException
    {
        public TripNotFoundException() : base("trip not found")
        {
        }
    }
}
