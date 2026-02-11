using FluentValidation;
using MapsterMapper;
using ProjectCalendar.Application.Common;
using ProjectCalendar.Communication.Requests;
using ProjectCalendar.Communication.Responses;
using ProjectCalendar.Domain.Interfaces;
using ProjectCalendar.Exceptions;
using ProjectCalendar.Exceptions.ExceptionsBase;

namespace ProjectCalendar.Application.UseCases.Event.Update
{
    public class UpdateEventUseCase : IUpdateEventUseCase
    {
        private readonly IEventRepository _repository;
        private readonly IMapper _mapper;
        private readonly IValidator<RequestUpdateEventJson> _validator;

        public UpdateEventUseCase(IEventRepository eventRepository, IMapper mapper, IValidator<RequestUpdateEventJson> validator)
        {
            _repository = eventRepository;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task<ResponseEventJson> Execute(string id, RequestUpdateEventJson request)
        {
            
            if (string.IsNullOrWhiteSpace(id) || id.Length != 24 || !id.All(Uri.IsHexDigit))
                throw new ErrorOnValidationException(new List<string>
                    {
                        ResourceMessagesException.INVALID_EVENT_ID
                    });

            await _validator.ValidateDomainAsync(request);

            var existingEvent = await _repository.GetByIdAsync(id);

            if (existingEvent is null)
                throw new ErrorNotFoundEventException();

            if (existingEvent.Title != request.Title)
                existingEvent.UpdateTitle(request.Title);

            var newDescription = request.Description?.Trim();

            if (existingEvent.Description != newDescription)
                existingEvent.UpdateDescription(newDescription);

            if (existingEvent.DateRange.StartDate != request.StartDate ||
                existingEvent.DateRange.EndDate != request.EndDate)
                existingEvent.UpdateDateRange(request.StartDate, request.EndDate);

            if (existingEvent.Color.Value != request.Color)
                existingEvent.UpdateColor(request.Color);

            await _repository.UpdateAsync(existingEvent);

            return _mapper.Map<ResponseEventJson>(existingEvent);
        }
    }
}
