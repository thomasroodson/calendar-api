using MapsterMapper;
using ProjectCalendar.Communication.Responses;
using ProjectCalendar.Domain.Interfaces;

namespace ProjectCalendar.Application.UseCases.Event.Get
{
    private readonly IEventRepository _repository;
    private readonly IMapper _mapper;

    public class GetByIdEventUseCase : IGetByIdEventUseCase
    {
        public async Task<ResponseEventJson> Execute(string id)
        {
            var itemEvent = 

        }
    }
}
