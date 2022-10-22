namespace TripBookingApi.Domain.Exceptions
{
    public class ExceptionMessage
    {
        public int StatusCode { get; set; }
        public string Content { get; set; } = "";
    }
}
