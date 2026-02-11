using FluentValidation;
using ProjectCalendar.Exceptions.ExceptionsBase;

namespace ProjectCalendar.Application.Common
{
    public static class ValidationExtensions
    {
        public static async Task ValidateDomainAsync<T>(this IValidator<T> validator, T instance, CancellationToken cancellationToken = default)
        {
            if (validator is null) throw new ArgumentNullException(nameof(validator));

            var validationResult = await validator.ValidateAsync(instance, cancellationToken).ConfigureAwait(false);

            if (!validationResult.IsValid)
            {
                var errorMessages = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                throw new ErrorOnValidationException(errorMessages);
            }
        }
    }
}
