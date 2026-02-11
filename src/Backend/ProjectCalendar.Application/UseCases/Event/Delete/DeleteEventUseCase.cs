using FluentValidation;
using ProjectCalendar.Application.Common;
using ProjectCalendar.Domain.Interfaces;
using ProjectCalendar.Exceptions.ExceptionsBase;

namespace ProjectCalendar.Application.UseCases.Event.Delete
{
    public class DeleteEventUseCase : IDeleteEventUseCase
    {
        private readonly IEventRepository _repository;
        private readonly IValidator<string> _validator;
        public DeleteEventUseCase(IEventRepository repository, IValidator<string> validator)
        {
            _repository = repository;
            _validator = validator;
        }
        public async Task Execute(string id)
        {
            await _validator.ValidateDomainAsync(id);

            var deleted = await _repository.DeleteAsync(id);

            if (!deleted)
                throw new ErrorNotFoundEventException();

        }
    }
}
