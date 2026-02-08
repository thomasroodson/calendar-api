using MapsterMapper;
using ProjectCalendar.Communication.Responses;
using ProjectCalendar.Domain.Interfaces;
using ProjectCalendar.Exceptions;
using ProjectCalendar.Exceptions.ExceptionsBase;

namespace ProjectCalendar.Application.UseCases.Event.Get
{
    public class GetEventByIdUseCase : IGetEventByIdUseCase
    {
        private readonly IEventRepository _repository;
        private readonly IMapper _mapper;

        public GetEventByIdUseCase(IEventRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ResponseEventJson> Execute(string id) 
        { 
          var eventById = await _repository.GetByIdAsync(id);

            return eventById == null
                ? throw new ErrorNotFoundEventException(ResourceMessagesException.NOT_FOUND_EVENT)
                : _mapper.Map<ResponseEventJson>(eventById!);
        }
    }
}
