using FluentValidation;
using ProjectCalendar.Communication.Requests;
using ProjectCalendar.Exceptions;

namespace ProjectCalendar.Application.UseCases.Event.Register
{
    public class RegisterEventValidator : AbstractValidator<RequestRegisterEventJson>
    {
        public RegisterEventValidator() 
        {
            RuleFor(request => request.Title)
            .NotEmpty()
            .WithMessage(ResourceMessagesException.TITLE_EMPTY)
            .MinimumLength(1)
            .WithMessage(ResourceMessagesException.TITLE_MIN_LENGTH)
            .MaximumLength(100)
            .WithMessage(ResourceMessagesException.TITLE_MAX_LENGTH)
            .Must(title => !string.IsNullOrWhiteSpace(title))
            .WithMessage(ResourceMessagesException.TITLE_WHITESPACE);

            RuleFor(request => request.Color)
                .NotEmpty()
                .WithMessage(ResourceMessagesException.COLOR_EMPTY)
                .Matches(@"^#([A-Fa-f0-9]{6})$")
                .WithMessage(ResourceMessagesException.COLOR_INVALID_FORMAT);

            RuleFor(request => request.StartDate)
                .NotEmpty()
                .WithMessage(ResourceMessagesException.START_DATE_REQUIRED)
                .LessThan(request => request.EndDate)
                .WithMessage(ResourceMessagesException.START_DATE_BEFORE_END);

            RuleFor(request => request.EndDate)
                .NotEmpty()
                .WithMessage(ResourceMessagesException.END_DATE_REQUIRED)
                .GreaterThan(request => request.StartDate)
                .WithMessage(ResourceMessagesException.END_DATE_AFTER_START);

            RuleFor(request => request)
                .Must(request => (request.EndDate - request.StartDate).TotalMinutes >= 1)
                .WithMessage(ResourceMessagesException.DURATION_MINIMUM)
                .When(request => request.EndDate > request.StartDate);

            RuleFor(request => request.Description)
                .MaximumLength(500)
                .WithMessage(ResourceMessagesException.DESCRIPTION_MAX_LENGTH)
                .When(request => request.Description != null);
        }
    }
}
