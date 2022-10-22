using MediatR;
using Microsoft.EntityFrameworkCore;
using TripBookingApi.Application.Countries.Queries.ViewModels;
using TripBookingApi.Application.Interfaces;

namespace TripBookingApi.Application.Countries.Queries
{
    public class GetAllCountriesQuery : IRequest<List<CountryListViewModel>>
    {

    }

    public class GetAllCountriesQueryHandler : IRequestHandler<GetAllCountriesQuery, List<CountryListViewModel>>
    {
        private readonly IDbContext _dbContext;
        public GetAllCountriesQueryHandler(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Task<List<CountryListViewModel>> Handle(GetAllCountriesQuery request, CancellationToken cancellationToken)
        {
            return _dbContext.Countries
                .Select(c => new CountryListViewModel(c.Id, c.CountryName))
                .ToListAsync(cancellationToken);
        }
    }
}
