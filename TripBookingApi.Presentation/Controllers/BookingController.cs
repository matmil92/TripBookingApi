using MediatR;
using Microsoft.AspNetCore.Mvc;
using TripBookingApi.Application.Bookings.Commands;

namespace TripBookingApi.Presentation.Controllers
{
    public class BookingController : BaseController
    {
        public BookingController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost]
        public async Task<ActionResult> Register(RegisterBookingCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpDelete]
        public async Task<ActionResult> Unregister([FromQuery] UnregisterBookingCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
    }
}
