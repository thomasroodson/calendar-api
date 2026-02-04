using ProjectCalendar.Communication.Requests;
using ProjectCalendar.Communication.Responses;

namespace ProjectCalendar.Application.UseCases.Event.Register
{
    public interface IRegisterEventUseCase
    {
        Task<ResponseRegisterEventJson> Execute(RequestRegisterEventJson request);
    }
}
