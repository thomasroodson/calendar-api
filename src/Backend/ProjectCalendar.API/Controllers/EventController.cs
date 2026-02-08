using Microsoft.AspNetCore.Mvc;
using ProjectCalendar.Application.UseCases.Event.Get;
using ProjectCalendar.Application.UseCases.Event.GetAll;
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
        private readonly IGetAllEventUseCase _getAllEventUseCase;
        private readonly IGetEventByIdUseCase _getEventByIdUseCase;

        public EventController(IRegisterEventUseCase registerEventUseCase,
            IGetAllEventUseCase getAllEventUseCase,
            IGetEventByIdUseCase getEventByIdUseCase
            )
        {
            _registerEventUseCase = registerEventUseCase;
            _getAllEventUseCase = getAllEventUseCase;

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
        public async Task<IActionResult> GetEventById(string id)
        {
            var result = await _getEventByIdUseCase.Execute(id);

            return Ok(result);
        }
    }
}
