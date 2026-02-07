using ProjectCalendar.Communication.Responses;

namespace ProjectCalendar.Application.UseCases.Event.Get
{
    public interface IGetByIdEventUseCase
    {
        Task<ResponseEventJson> Execute(string id);
    }
}
