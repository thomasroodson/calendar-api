using FluentValidation;
using MapsterMapper;
using ProjectCalendar.Application.Common;
using ProjectCalendar.Communication.Requests;
using ProjectCalendar.Communication.Responses;
using ProjectCalendar.Domain.Interfaces;
using ProjectCalendar.Exceptions.ExceptionsBase;

namespace ProjectCalendar.Application.UseCases.Event.GetByDate
{
    public class GetEventsByDateUseCase : IGetEventsByDateUseCase
    {
        private readonly IEventRepository _repository;
        private readonly IMapper _mapper;
        private readonly IValidator<RequestGetEventByDateJson> _validator;
        public GetEventsByDateUseCase(IEventRepository repository, IMapper mapper, IValidator<RequestGetEventByDateJson> validator)
        {
            _repository = repository;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task<IEnumerable<ResponseEventJson>> Execute(RequestGetEventByDateJson request)
        {
            await _validator.ValidateDomainAsync(request);

            var events = await _repository.GetByDateRangeAsync(request.StartDate, request.EndDate);
            var result = _mapper.Map<IEnumerable<ResponseEventJson>>(events);

            return result;
        }

    }
}
