using Microsoft.AspNetCore.Mvc;
using ProjectCalendar.Application.UseCases.Event.Delete;
using ProjectCalendar.Application.UseCases.Event.GetAll;
using ProjectCalendar.Application.UseCases.Event.GetByDate;
using ProjectCalendar.Application.UseCases.Event.GetById;
using ProjectCalendar.Application.UseCases.Event.Register;
using ProjectCalendar.Application.UseCases.Event.Update;
using ProjectCalendar.Communication.Requests;
using ProjectCalendar.Communication.Responses;

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
        private readonly IUpdateEventUseCase _updateEventUseCase;
        private readonly IDeleteEventUseCase _deletEventUseCase;

        public EventController(IRegisterEventUseCase registerEventUseCase,
            IGetAllEventsUseCase getAllEventUseCase,
            IGetEventByIdUseCase getEventByIdUseCase,
            IGetEventsByDateUseCase getEventByDateUseCase,
            IUpdateEventUseCase updateEventUseCase,
            IDeleteEventUseCase deleteEventUseCase
            )
        {
            _registerEventUseCase = registerEventUseCase;
            _getAllEventUseCase = getAllEventUseCase;
            _getEventByIdUseCase = getEventByIdUseCase;
            _getEventByDateUseCase = getEventByDateUseCase;
            _updateEventUseCase = updateEventUseCase;
            _deletEventUseCase = deleteEventUseCase;
        }

        [HttpPost]
        [ProducesResponseType(typeof(ResponseEventJson), StatusCodes.Status201Created)]
        public async Task<IActionResult> Register([FromBody] RequestRegisterEventJson request)
        {
            var result = await _registerEventUseCase.Execute(request);

            return CreatedAtAction(nameof(GetEventById), new { id = result.Id }, result);
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
            [FromRoute] string id)
        {
            var result = await _getEventByIdUseCase.Execute(id);

            return Ok(result);
        }

        [HttpGet("range")]
        [ProducesResponseType(typeof(IEnumerable<ResponseEventJson>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetEventsByDate(
            [FromQuery] RequestGetEventByDateJson request)
        {
            var result = await _getEventByDateUseCase.Execute(request);
            return Ok(result);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(ResponseEventJson), StatusCodes.Status200OK)]
        public async Task<IActionResult> Update(
            [FromRoute] string id,
            [FromBody] RequestUpdateEventJson request)
        {

            var result = await _updateEventUseCase.Execute(id, request);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Delete(
            [FromRoute] string id)
        {
            await _deletEventUseCase.Execute(id);
            return NoContent();
        }
    }
}
