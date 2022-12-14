using MediatR;
using System.ComponentModel.DataAnnotations;
using TripBookingApi.Application.Interfaces;
using TripBookingApi.Domain.Entities;
using TripBookingApi.Domain.Exceptions.Country;

namespace TripBookingApi.Application.Trips.Commands
{
    public class CreateTripCommand : IRequest
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

    public class CreateTripCommandHandler : IRequestHandler<CreateTripCommand>
    {
        private readonly IDbContext _dbContext;
        public CreateTripCommandHandler(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Unit> Handle(CreateTripCommand request, CancellationToken cancellationToken)
        {
            var country = await _dbContext.Countries.FindAsync(request.CountryId) ?? throw new CountryNotFoundException();
            await _dbContext.Trips.AddAsync(
                new Trip(request.Name, country, request.Description, request.StartDate, request.NumberOfSeats));
            await _dbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
