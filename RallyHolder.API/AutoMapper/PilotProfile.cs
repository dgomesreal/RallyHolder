using AutoMapper;
using RallyHolder.API.Model;
using RallyHolder.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
