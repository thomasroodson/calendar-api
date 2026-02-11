using FluentValidation;
using ProjectCalendar.Communication.Requests;
using ProjectCalendar.Exceptions;

namespace ProjectCalendar.Application.UseCases.Event.Update
{
    public class UpdateEventValidator : AbstractValidator<RequestUpdateEventJson>
    {
        public UpdateEventValidator()
        {
            RuleFor(x => x.Title)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage(ResourceMessagesException.TITLE_EMPTY)
                .Must(title => !string.IsNullOrWhiteSpace(title))
                .WithMessage(ResourceMessagesException.TITLE_WHITESPACE)
                .MaximumLength(100)
                .WithMessage(ResourceMessagesException.TITLE_MAX_LENGTH);

            RuleFor(x => x.Color)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage(ResourceMessagesException.COLOR_EMPTY)
                .Matches(@"^#([A-Fa-f0-9]{6})$")
                .WithMessage(ResourceMessagesException.COLOR_INVALID_FORMAT);

            RuleFor(x => x.StartDate)
                .NotEmpty()
                .WithMessage(ResourceMessagesException.START_DATE_REQUIRED)
                .LessThan(x => x.EndDate)
                .WithMessage(ResourceMessagesException.INVALID_EVENT_DATE_RANGE);

            RuleFor(x => x.EndDate)
                .NotEmpty()
                .WithMessage(ResourceMessagesException.END_DATE_REQUIRED);

            RuleFor(x => x)
                .Must(x => (x.EndDate - x.StartDate).TotalMinutes >= 1)
                .WithMessage(ResourceMessagesException.DURATION_MINIMUM)
                .When(x => x.EndDate > x.StartDate);

            RuleFor(x => x.Description)
                .MaximumLength(500)
                .WithMessage(ResourceMessagesException.DESCRIPTION_MAX_LENGTH)
                .When(x => x.Description != null);
        }
    }
}
