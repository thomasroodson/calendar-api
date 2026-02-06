using ProjectCalendar.Communication.Responses;

namespace ProjectCalendar.Application.UseCases.Event.GetAll
{
    public interface IGetAllEventUseCase
    {
        Task<IEnumerable<ResponseEventJson>> Execute();
    }
}
