using MediatR;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using TripBookingApi.Application.Interfaces;
using TripBookingApi.Domain.Entities;

namespace TripBookingApi.Application.Bookings.Commands
{
    public class RegisterBookingCommand : IRequest
    {
        [Required]
        public string TripName { get; set; } = "";
        [Required]
        public string Email { get; set; } = "";
    }

    public class RegisterBookingCommandHandler : IRequestHandler<RegisterBookingCommand>
    {
        private readonly IDbContext _dbContext;
        public RegisterBookingCommandHandler(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Unit> Handle(RegisterBookingCommand request, CancellationToken cancellationToken)
        {
            var trip = await _dbContext.Trips
                .Include(b => b.Bookings)
                .FirstOrDefaultAsync(t => t.Name == request.TripName) ?? throw new Exception("trip not found");
            var booking = trip.Bookings.Find(b => b.Email == request.Email);
            if(booking != null)
            {
                throw new Exception("email is already registered");
            }
            trip.Bookings.Add(new Booking(trip, request.Email));
            _dbContext.Trips.Update(trip);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
