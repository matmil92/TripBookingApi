namespace TripBookingApi.Application.Countries.Queries.ViewModels
{
    public class CountryListViewModel
    {
        public CountryListViewModel(int id, string countryName)
        {
            Id = id;
            CountryName = countryName;
        }

        public int Id { get; private set; }
        public string CountryName { get; private set; }
    }
}
