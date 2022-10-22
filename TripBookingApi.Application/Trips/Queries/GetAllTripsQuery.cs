using MediatR;
using Microsoft.EntityFrameworkCore;
using TripBookingApi.Application.Interfaces;
using TripBookingApi.Application.Trips.Queries.ViewModels;

namespace TripBookingApi.Application.Trips.Queries
{
    public class GetAllTripsQuery : IRequest<IEnumerable<TripListViewModel>>
    {
    }

    public class GetAllTripsQueryHandler : IRequestHandler<GetAllTripsQuery, IEnumerable<TripListViewModel>>
    {
        private readonly IDbContext _dbContext;
        public GetAllTripsQueryHandler(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<TripListViewModel>> Handle(GetAllTripsQuery request, CancellationToken cancellationToken)
        {
            var list = await _dbContext.Trips.Include(t => t.Country).ToListAsync(cancellationToken);
            return list
                .Select(t =>
                    new TripListViewModel(t.Name, t.Country.CountryName, t.StartDate, t.NumberOfSeats));
        }
    }
}
