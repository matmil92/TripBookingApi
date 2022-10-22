using MediatR;
using Microsoft.AspNetCore.Mvc;
using TripBookingApi.Application.Trips.Commands;
using TripBookingApi.Application.Trips.Queries;
using TripBookingApi.Application.Trips.Queries.ViewModels;

namespace TripBookingApi.Presentation.Controllers
{
    public class TripController : BaseController
    {
        private readonly IMediator _mediator;
        public TripController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("list")]
        public async Task<ActionResult<IEnumerable<TripListViewModel>>> GetList()
        {
            return Ok(await _mediator.Send(new GetAllTripsQuery()));
        }

        [HttpGet("details")]
        public async Task<ActionResult<IEnumerable<TripListViewModel>>> GetList([FromQuery] GetTripDetailQuery query)
        {
            return Ok(await _mediator.Send(query));
        }

        [HttpPost]
        public async Task<ActionResult> Create(CreateTripCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpPut]
        public async Task<ActionResult> Create(UpdateTripCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpDelete]
        public async Task<ActionResult> Create([FromQuery] DeleteTripCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
    }
}
