using Microsoft.AspNetCore.Mvc;
using ProjectCalendar.Application.UseCases.Event.Register;
using ProjectCalendar.Communication.Requests;
using ProjectCalendar.Communication.Responses;

namespace ProjectCalendar.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IRegisterEventUseCase _registerEventUseCase;

        public EventController(IRegisterEventUseCase registerEventUseCase)
        {
            _registerEventUseCase = registerEventUseCase;
        }

        [HttpPost]
        [ProducesResponseType(typeof(ResponseRegisterEventJson), StatusCodes.Status201Created)]
        public async Task<IActionResult> Register([FromBody] RequestRegisterEventJson request)
        {
            var result = await _registerEventUseCase.Execute(request);

            return Created(string.Empty, result);
        }
    }
}
