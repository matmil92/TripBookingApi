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
            await _mediator.Send(command);
            return Ok();
        }

        [HttpDelete]
        public async Task<ActionResult> Unregister([FromQuery] UnregisterBookingCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }
    }
}
