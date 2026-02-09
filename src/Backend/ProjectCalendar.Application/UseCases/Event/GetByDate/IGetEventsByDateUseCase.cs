using ProjectCalendar.Communication.Requests;
using ProjectCalendar.Communication.Responses;

namespace ProjectCalendar.Application.UseCases.Event.GetByDate
{
    public interface IGetEventsByDateUseCase
    {
        Task<IEnumerable<ResponseEventJson>> Execute(RequestGetEventByDateJson request);
    }
}
