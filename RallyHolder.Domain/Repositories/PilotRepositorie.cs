using RallyHolder.Domain.Context;
using RallyHolder.Domain.Entities;
using System.Linq;
using System.Collections.Generic;
using RallyHolder.Domain.Interfaces;

namespace RallyHolder.Domain.Repositories
{
    public class PilotRepositorie : IPilotRepositorie
    {
        private readonly RallyDbContext _rallyDbContext;
        public PilotRepositorie(RallyDbContext rallyDbContext)
        {
            _rallyDbContext = rallyDbContext;
        }

        public void AddPilot(Pilot pilot)
        {
            _rallyDbContext.Pilots.Add(pilot);
            _rallyDbContext.SaveChanges();
        }

        public IEnumerable<Pilot> GetAllPilots()
        {
            return _rallyDbContext.Pilots.ToList();
        }
    }
}
