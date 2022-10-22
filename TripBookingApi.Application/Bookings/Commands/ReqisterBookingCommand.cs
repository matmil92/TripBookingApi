using MediatR;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using TripBookingApi.Application.Interfaces;
using TripBookingApi.Domain.Entities;
using TripBookingApi.Domain.Exceptions.Booking;
using TripBookingApi.Domain.Exceptions.Trip;

namespace TripBookingApi.Application.Bookings.Commands
{
    public class RegisterBookingCommand : IRequest
    {
        [Required]
        [MaxLength(200)]
        public string TripName { get; set; } = "";
        [Required]
        [EmailAddress]
        [MaxLength(200)]
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
                .FirstOrDefaultAsync(t => t.Name == request.TripName) ?? throw new TripNotFoundException();
            var booking = trip.Bookings.Find(b => b.Email == request.Email);
            if(booking != null)
            {
                throw new BookingFoundException();
            }
            trip.Bookings.Add(new Booking(trip, request.Email));
            _dbContext.Trips.Update(trip);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
