namespace ProjectCalendar.Application.UseCases.Event.Delete
{
    public interface IDeleteEventUseCase
    {
        Task Execute(string id);
    }
}
