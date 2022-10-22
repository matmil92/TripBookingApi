using MediatR;
using TripBookingApi.Application.Countries.Queries;
using TripBookingApi.Application.Countries.Queries.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace TripBookingApi.Presentation.Controllers
{
    public class CountryController : BaseController
    {
        public CountryController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet("list")]
        public async Task<ActionResult<IEnumerable<CountryListViewModel>>> GetList()
        {
            return Ok(await _mediator.Send(new GetAllCountriesQuery()));
        }
    }
}
