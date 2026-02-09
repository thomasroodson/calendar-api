using MapsterMapper;
using ProjectCalendar.Communication.Responses;
using ProjectCalendar.Domain.Interfaces;

namespace ProjectCalendar.Application.UseCases.Event.GetAll
{
    public class GetAllEventsUseCase : IGetAllEventsUseCase
    {
        private readonly IEventRepository _repository;
        private readonly IMapper _mapper;
        public GetAllEventsUseCase(IEventRepository repository, IMapper mapper) {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<ResponseEventJson>> Execute()
        {
            var getAllEvent = await _repository.GetAllAsync();

            var response = _mapper.Map<IEnumerable<ResponseEventJson>>(getAllEvent);

            return response;
        }
    }
}
