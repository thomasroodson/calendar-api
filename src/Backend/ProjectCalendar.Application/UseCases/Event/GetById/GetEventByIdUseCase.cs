using FluentValidation;
using MapsterMapper;
using ProjectCalendar.Communication.Responses;
using ProjectCalendar.Domain.Interfaces;
using ProjectCalendar.Exceptions.ExceptionsBase;

namespace ProjectCalendar.Application.UseCases.Event.GetById
{
    public class GetEventByIdUseCase : IGetEventByIdUseCase
    {
        private readonly IEventRepository _repository;
        private readonly IMapper _mapper;
        private readonly IValidator<string> _validator;

        public GetEventByIdUseCase(IEventRepository repository, IMapper mapper, IValidator<string> validator)
        {
            _repository = repository;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task<ResponseEventJson> Execute(string id)
        {
            await Validate(id);

            var eventById = await _repository.GetByIdAsync(id);

            return eventById is null  ? throw new ErrorNotFoundEventException() : _mapper.Map<ResponseEventJson>(eventById);
        }

        private async Task Validate(string id)
        {
            var validationResult = await _validator.ValidateAsync(id);

            if (!validationResult.IsValid)
            {
                var errorMessages = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                throw new ErrorOnValidationException(errorMessages);
            }
        }
    }
}
