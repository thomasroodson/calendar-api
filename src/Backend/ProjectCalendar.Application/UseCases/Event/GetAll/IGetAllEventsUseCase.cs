using ProjectCalendar.Communication.Responses;

namespace ProjectCalendar.Application.UseCases.Event.GetAll
{
    public interface IGetAllEventsUseCase
    {
        Task<IEnumerable<ResponseEventJson>> Execute();
    }
}
