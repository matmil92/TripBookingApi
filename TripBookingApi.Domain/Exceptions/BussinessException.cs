namespace TripBookingApi.Domain.Exceptions
{
    public abstract class BussinessException : Exception
    {
        public BussinessException(string message) : base(message)
        {

        }
    }
}
