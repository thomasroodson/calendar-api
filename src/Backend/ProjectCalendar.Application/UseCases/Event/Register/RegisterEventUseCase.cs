using FluentValidation;
using MapsterMapper;
using ProjectCalendar.Application.Common;
using ProjectCalendar.Communication.Requests;
using ProjectCalendar.Communication.Responses;
using ProjectCalendar.Domain.Interfaces;
using ProjectCalendar.Exceptions.ExceptionsBase;

namespace ProjectCalendar.Application.UseCases.Event.Register
{
    public class RegisterEventUseCase : IRegisterEventUseCase
    {
        private readonly IEventRepository _repository;
        private readonly IValidator<RequestRegisterEventJson> _validator;
        private readonly IMapper _mapper;

        public RegisterEventUseCase(
            IEventRepository repository,
            IValidator<RequestRegisterEventJson> validator,
            IMapper mapper)
        {
            _repository = repository;
            _validator = validator;
            _mapper = mapper;
        }

        public async Task<ResponseEventJson> Execute(RequestRegisterEventJson request)
        {
            await _validator.ValidateDomainAsync(request);

            var eventEntity = new Domain.Entities.Event(
                title: request.Title,
                startDate: request.StartDate,
                endDate: request.EndDate,
                color: request.Color,
                description: request.Description
            );

            var createdEvent = await _repository.CreateAsync(eventEntity);

            return _mapper.Map<ResponseEventJson>(createdEvent);
        }
    }
}