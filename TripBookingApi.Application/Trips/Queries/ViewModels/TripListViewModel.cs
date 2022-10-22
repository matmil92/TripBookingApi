namespace TripBookingApi.Application.Trips.Queries.ViewModels
{
    public class TripListViewModel
    {
        public TripListViewModel(string name, string countryName, DateTime startDate, int numberOfSeats)
        {
            Name = name;
            CountryName = countryName;
            StartDate = startDate;
            NumberOfSeats = numberOfSeats;
        }

        public string Name { get; private set; }
        public string CountryName { get; private set; }
        public DateTime StartDate { get; private set; }
        public int NumberOfSeats { get; private set; }
    }
}
