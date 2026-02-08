using ProjectCalendar.Communication.Responses;

namespace ProjectCalendar.Application.UseCases.Event.Get
{
    public interface IGetEventByIdUseCase
    {
        Task<ResponseEventJson> Execute(string id);
    }
}
