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

        public void Add(Pilot pilot)
        {
            _rallyDbContext.Pilots.Add(pilot);
            _rallyDbContext.SaveChanges();
        }

        public void Delete(Pilot pilot)
        {
            _rallyDbContext.Pilots.Remove(pilot);
            _rallyDbContext.SaveChanges();
        }

        public bool Exist(int pilotId)
        {
            return _rallyDbContext.Pilots.Any(p => p.Id == pilotId);
        }

        public Pilot Get(int pilotId)
        {
            return _rallyDbContext.Pilots.FirstOrDefault(p => p.Id == pilotId);
        }

        public IEnumerable<Pilot> GetAll()
        {
            return _rallyDbContext.Pilots.ToList();
        }

        public void Update(Pilot pilot)
        {
            _rallyDbContext.Attach(pilot);
            _rallyDbContext.Entry(pilot).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _rallyDbContext.SaveChanges();
        }
    }
}
