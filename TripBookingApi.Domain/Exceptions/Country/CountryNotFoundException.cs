namespace TripBookingApi.Domain.Exceptions.Country
{
    public class CountryNotFoundException : BussinessException
    {
        public CountryNotFoundException() : base("country not found")
        {

        }
    }
}
