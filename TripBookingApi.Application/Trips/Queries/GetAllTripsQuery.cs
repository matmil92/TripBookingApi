using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripBookingApi.Application.Interfaces;
using TripBookingApi.Application.Trips.Queries.ViewModels;

namespace TripBookingApi.Application.Trips.Queries
{
    public class GetAllTripsQuery : IRequest<List<TripListViewModel>>
    {
    }

    public class GetAllTripsQueryHandler : IRequestHandler<GetAllTripsQuery, List<TripListViewModel>>
    {
        private readonly IDbContext _dbContext;
        public GetAllTripsQueryHandler(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<TripListViewModel>> Handle(GetAllTripsQuery request, CancellationToken cancellationToken)
        {
            return await _dbContext.Trips
                .Include(t => t.Country)
                .Select(t => 
                    new TripListViewModel(t.Name, t.Country.CountryName, t.StartDate, t.NumberOfSeats))
                .ToListAsync(cancellationToken);
        }
    }
}
