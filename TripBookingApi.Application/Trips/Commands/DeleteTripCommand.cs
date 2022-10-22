using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripBookingApi.Application.Interfaces;
using TripBookingApi.Domain.Entities;

namespace TripBookingApi.Application.Trips.Commands
{
    public class DeleteTripCommand : IRequest
    {
        public string Name { get; set; } = "";
    }

    public class DeleteTripCommandHandler : IRequestHandler<DeleteTripCommand>
    {
        private readonly IDbContext _dbContext;
        public DeleteTripCommandHandler(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Unit> Handle(DeleteTripCommand request, CancellationToken cancellationToken)
        {
            var trip = await _dbContext.Trips.FindAsync(request.Name) ?? throw new Exception("trip not found");
            _dbContext.Trips.Remove(trip);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
