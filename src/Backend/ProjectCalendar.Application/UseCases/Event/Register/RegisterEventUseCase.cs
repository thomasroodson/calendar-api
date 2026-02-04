using FluentValidation;
using MapsterMapper;
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

        public async Task<ResponseRegisterEventJson> Execute(RequestRegisterEventJson request)
        {
            await Validate(request);

            var eventEntity = new Domain.Entities.Event(
                title: request.Title,
                startDate: request.StartDate,
                endDate: request.EndDate,
                color: request.Color,
                description: request.Description
            );

            var createdEvent = await _repository.CreateAsync(eventEntity);

            return _mapper.Map<ResponseRegisterEventJson>(createdEvent);
        }

        private async Task Validate(RequestRegisterEventJson request)
        {
            var result = await _validator.ValidateAsync(request);

            if (!result.IsValid)
            {
                var errorMessages = result.Errors.Select(e => e.ErrorMessage).ToList();
                throw new ErrorOnValidationException(errorMessages);
            }
        }
    }
}