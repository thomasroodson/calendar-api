using Mapster;
using ProjectCalendar.Communication.Responses;
using ProjectCalendar.Domain.Entities;

namespace ProjectCalendar.Application.Mappings
{
    public class EventMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config) 
        {
            config.NewConfig<Event, ResponseRegisterEventJson>()
            .Map(dest => dest.Id, src => src.Id)
            .Map(dest => dest.Title, src => src.Title)
            .Map(dest => dest.Description, src => src.Description)
            .Map(dest => dest.StartDate, src => src.DateRange.StartDate)
            .Map(dest => dest.EndDate, src => src.DateRange.EndDate)
            .Map(dest => dest.Color, src => src.Color.Value)
            .Map(dest => dest.CreatedAt, src => src.CreatedAt)
            .Map(dest => dest.UpdatedAt, src => src.UpdatedAt);
        }
    }
}
