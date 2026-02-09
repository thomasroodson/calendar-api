using FluentValidation;
using ProjectCalendar.Communication.Requests;
using ProjectCalendar.Exceptions;

namespace ProjectCalendar.Application.UseCases.Event.GetByDate
{
    public class GetEventByDateValidator : AbstractValidator<RequestGetEventByDateJson>
    {
        public GetEventByDateValidator()
        {
            RuleFor(x => x)
                .Must(x => x.StartDate <= x.EndDate)
                .WithMessage(ResourceMessagesException.INVALID_EVENT_DATE_RANGE);
        }
    }
}
