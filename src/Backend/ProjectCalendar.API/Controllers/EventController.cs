using Microsoft.AspNetCore.Mvc;
using ProjectCalendar.Application.UseCases.Event.GetById;
using ProjectCalendar.Application.UseCases.Event.GetAll;
using ProjectCalendar.Application.UseCases.Event.Register;
using ProjectCalendar.Communication.Requests;
using ProjectCalendar.Communication.Responses;
using ProjectCalendar.Exceptions;
using ProjectCalendar.Application.UseCases.Event.GetByDate;

namespace ProjectCalendar.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IRegisterEventUseCase _registerEventUseCase;
        private readonly IGetAllEventsUseCase _getAllEventUseCase;
        private readonly IGetEventByIdUseCase _getEventByIdUseCase;
        private readonly IGetEventsByDateUseCase _getEventByDateUseCase;

        public EventController(IRegisterEventUseCase registerEventUseCase,
            IGetAllEventsUseCase getAllEventUseCase,
            IGetEventByIdUseCase getEventByIdUseCase,
            IGetEventsByDateUseCase getEventByDateUseCase
            )
        {
            _registerEventUseCase = registerEventUseCase;
            _getAllEventUseCase = getAllEventUseCase;
            _getEventByIdUseCase = getEventByIdUseCase;
            _getEventByDateUseCase = getEventByDateUseCase;

        }

        [HttpPost]
        [ProducesResponseType(typeof(ResponseEventJson), StatusCodes.Status201Created)]
        public async Task<IActionResult> Register([FromBody] RequestRegisterEventJson request)
        {
            var result = await _registerEventUseCase.Execute(request);

            return Created(string.Empty, result);
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ResponseEventJson>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            var result = await _getAllEventUseCase.Execute();

            return Ok(result);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ResponseEventJson), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetEventById(
            [FromRoute]string id)
        {
            var result = await _getEventByIdUseCase.Execute(id);

            return Ok(result);
        }

        [HttpGet("range")]
        [ProducesResponseType(typeof(IEnumerable<ResponseEventJson>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetEventsByDate(
            [FromQuery] RequestGetEventByDateJson request)
        {
            var result = _getEventByDateUseCase.Execute(request);
            return Ok(result);
        }
    }
}
