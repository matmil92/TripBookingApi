using MediatR;
using Microsoft.AspNetCore.Mvc;
using TripBookingApi.Application.Trips.Queries;
using TripBookingApi.Application.Trips.Queries.ViewModels;

namespace TripBookingApi.Presentation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TripController : ControllerBase
    {
        private readonly IMediator _mediator;
        public TripController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("list")]
        public async Task<ActionResult<List<TripListViewModel>>> GetList()
        {
            return await _mediator.Send(new GetAllTripsQuery());
        }
    }
}
