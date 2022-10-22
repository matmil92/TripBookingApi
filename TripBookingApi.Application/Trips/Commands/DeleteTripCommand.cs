using MediatR;
using System.ComponentModel.DataAnnotations;
using TripBookingApi.Application.Interfaces;
using TripBookingApi.Domain.Exceptions.Trip;

namespace TripBookingApi.Application.Trips.Commands
{
    public class DeleteTripCommand : IRequest
    {
        [Required]
        [MaxLength(200)]
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
            var trip = await _dbContext.Trips.FindAsync(request.Name) ?? throw new TripNotFoundException();
            _dbContext.Trips.Remove(trip);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
