using MediatR;
using TripBookingApi.Application.Interfaces;
using TripBookingApi.Application.Trips.Queries.ViewModels;

namespace TripBookingApi.Application.Trips.Queries
{
    public class GetTripDetailQuery : IRequest<TripDetailsViewModel>
    {
        public string TripName { get; set; } = "";
    }

    public class GetTripDetailsQueryHandler : IRequestHandler<GetTripDetailQuery, TripDetailsViewModel>
    {
        private readonly IDbContext _dbContext;
        public GetTripDetailsQueryHandler(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<TripDetailsViewModel> Handle(GetTripDetailQuery request, CancellationToken cancellationToken)
        {
            var trip = await _dbContext.Trips.FindAsync(request.TripName);
            if(trip != null)
            {
                return new TripDetailsViewModel(
                    trip.Name,
                    trip.Country.CountryName,
                    trip.Description,
                    trip.StartDate,
                    trip.NumberOfSeats,
                    trip.Bookings.Select(b => b.Email));
            }
            else
            {
                throw new Exception("trip not found");
            }
        }
    }
}
