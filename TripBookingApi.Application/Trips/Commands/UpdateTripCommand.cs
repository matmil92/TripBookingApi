using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripBookingApi.Application.Interfaces;
using TripBookingApi.Domain.Entities;

namespace TripBookingApi.Application.Trips.Commands
{
    public class UpdateTripCommand : IRequest
    {
        public string Name { get; set; } = "";
        public int CountryId { get; set; }
        public string Description { get; set; } = "";
        public DateTime StartDate { get; set; }
        public int NumberOfSeats { get; set; }
    }

    public class UpdateTripCommandHandler : IRequestHandler<UpdateTripCommand>
    {
        private readonly IDbContext _dbContext;
        public UpdateTripCommandHandler(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Unit> Handle(UpdateTripCommand request, CancellationToken cancellationToken)
        {
            var trip = await _dbContext.Trips
                .AsNoTracking()
                .FirstOrDefaultAsync(t => t.Name == request.Name) ?? throw new Exception("trip not found");
            var country = await _dbContext.Countries.FindAsync(request.CountryId) ?? throw new Exception("Country not found");
            _dbContext.Trips.Update(
                new Trip(request.Name, country, request.Description, request.StartDate, request.NumberOfSeats));
            await _dbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
