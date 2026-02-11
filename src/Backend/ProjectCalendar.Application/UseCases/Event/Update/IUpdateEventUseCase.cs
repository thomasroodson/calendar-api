using ProjectCalendar.Communication.Requests;
using ProjectCalendar.Communication.Responses;

namespace ProjectCalendar.Application.UseCases.Event.Update
{
    public interface IUpdateEventUseCase
    {
        Task<ResponseEventJson> Execute(
            string id,
            RequestUpdateEventJson request);
    }
}
