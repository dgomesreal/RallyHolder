using AutoMapper;
using RallyHolder.API.Model;
using RallyHolder.Domain.Entities;

namespace RallyHolder.API.AutoMapper
{
    public class PilotProfile : Profile
    {
        public PilotProfile()
        {
            CreateMap<Pilot, PilotModel>();
            CreateMap<PilotModel, Pilot>();
        }
    }
}
