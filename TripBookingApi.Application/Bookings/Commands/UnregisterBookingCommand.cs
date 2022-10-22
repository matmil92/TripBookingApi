using MediatR;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using TripBookingApi.Application.Interfaces;
using TripBookingApi.Domain.Exceptions.Booking;
using TripBookingApi.Domain.Exceptions.Trip;

namespace TripBookingApi.Application.Bookings.Commands
{
    public class UnregisterBookingCommand : IRequest
    {
        [Required]
        public string TripName { get; set; } = "";
        [Required]
        [EmailAddress]
        public string Email { get; set; } = "";
    }

    public class UnregisterBookingCommandHandler : IRequestHandler<UnregisterBookingCommand>
    {
        private readonly IDbContext _dbContext;
        public UnregisterBookingCommandHandler(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Unit> Handle(UnregisterBookingCommand request, CancellationToken cancellationToken)
        {
            var trip = await _dbContext.Trips
                .Include(b => b.Bookings)
                .FirstOrDefaultAsync(t => t.Name == request.TripName) ?? throw new TripNotFoundException();
            var booking = trip.Bookings.Find(b => b.Email == request.Email) ?? throw new BookingNotFoundException();
            trip.Bookings.Remove(booking);
            _dbContext.Trips.Update(trip);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
