using AutoMapper;
using RallyHolder.Domain.Entities;

namespace RallyHolder.API.AutoMapper
{
    public class TelemetryProfile : Profile
    {
        public TelemetryProfile()
        {
            CreateMap<Telemetry, TelemetryProfile>();
            CreateMap<TelemetryProfile, Telemetry>();
        }
    }
}
