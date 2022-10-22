namespace TripBookingApi.Application.Trips.Queries.ViewModels
{
    public class TripDetailsViewModel
    {
        public TripDetailsViewModel(string name, string countryName, string description, DateTime startDate, int numberOfSeats, IEnumerable<string> bookings)
        {
            Name = name;
            CountryName = countryName;
            Description = description;
            StartDate = startDate;
            NumberOfSeats = numberOfSeats;
            Bookings = bookings;
        }

        public string Name { get; private set; }
        public string CountryName { get; private set; }
        public string Description { get; private set; }
        public DateTime StartDate { get; private set; }
        public int NumberOfSeats { get; private set; }
        public IEnumerable<string> Bookings { get; private set; }
    }
}
