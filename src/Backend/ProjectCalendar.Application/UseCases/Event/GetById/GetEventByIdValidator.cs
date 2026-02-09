using FluentValidation;
using ProjectCalendar.Exceptions;

namespace ProjectCalendar.Application.UseCases.Event.GetById
{
    public class GetEventByIdValidator : AbstractValidator<string>
    {
        public GetEventByIdValidator() {
            RuleFor(id => id)
            .Cascade(CascadeMode.Stop)
            .NotEmpty()
            .WithMessage(ResourceMessagesException.INVALID_EVENT_ID)
            .Length(24)
            .WithMessage(ResourceMessagesException.INVALID_EVENT_ID)
            .Must(id => id.All(Uri.IsHexDigit))
            .WithMessage(ResourceMessagesException.INVALID_EVENT_ID);
        }
    }
}
