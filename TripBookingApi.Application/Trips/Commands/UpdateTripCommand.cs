using MediatR;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using TripBookingApi.Application.Interfaces;
using TripBookingApi.Domain.Entities;
using TripBookingApi.Domain.Exceptions.Country;
using TripBookingApi.Domain.Exceptions.Trip;

namespace TripBookingApi.Application.Trips.Commands
{
    public class UpdateTripCommand : IRequest
    {
        [Required]
        [MaxLength(200)]
        public string Name { get; set; } = "";
        [Required]
        public int CountryId { get; set; }
        [Required]
        [MaxLength(4000)]
        public string Description { get; set; } = "";
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
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
                .FirstOrDefaultAsync(t => t.Name == request.Name) ?? throw new TripNotFoundException();
            var country = await _dbContext.Countries.FindAsync(request.CountryId) ?? throw new CountryNotFoundException();
            _dbContext.Trips.Update(
                new Trip(request.Name, country, request.Description, request.StartDate, request.NumberOfSeats));
            await _dbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
