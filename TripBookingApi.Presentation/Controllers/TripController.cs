using MediatR;
using Microsoft.AspNetCore.Mvc;
using TripBookingApi.Application.Trips.Commands;
using TripBookingApi.Application.Trips.Queries;
using TripBookingApi.Application.Trips.Queries.ViewModels;

namespace TripBookingApi.Presentation.Controllers
{
    public class TripController : BaseController
    {
        public TripController(IMediator mediator) : base(mediator)
        {
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
            await _mediator.Send(command);
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> Create(UpdateTripCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [HttpDelete]
        public async Task<ActionResult> Delete([FromQuery] DeleteTripCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }
    }
}
