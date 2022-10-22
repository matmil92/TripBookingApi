using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripBookingApi.Application.Interfaces;

namespace TripBookingApi.Application.Trips.Commands
{
    public class CreateTripCommand : IRequest
    {
        public string Name { get; private set; }
        public Country Country { get; private set; }
        public string Description { get; private set; }
        public DateTime StartDate { get; private set; }
        public int NumberOfSeats { get; private set; }
    }

    public class CreateTripCommandHandler : IRequestHandler<CreateTripCommand>
    {
        private readonly IDbContext _dbContext;
        public CreateTripCommandHandler(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Task<Unit> Handle(CreateTripCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
