using ProjectCalendar.Communication.Responses;

namespace ProjectCalendar.Application.UseCases.Event.GetById
{
    public interface IGetEventByIdUseCase
    {
        Task<ResponseEventJson> Execute(string id);
    }
}
