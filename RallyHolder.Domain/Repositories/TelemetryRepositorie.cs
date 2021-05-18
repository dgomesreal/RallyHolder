using RallyHolder.Domain.Context;
using RallyHolder.Domain.Entities;
using RallyHolder.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RallyHolder.Domain.Repositories
{
    public class TelemetryRepositorie : ITelemetryRepositorie
    {
        private readonly RallyDbContext _rallyDbContext;

        public TelemetryRepositorie(RallyDbContext rallyDbContext)
        {
            _rallyDbContext = rallyDbContext;
        }

        public void Delete(Telemetry telemetry)
        {
            _rallyDbContext.Remove(telemetry);
            _rallyDbContext.SaveChanges();
        }

        public bool Exists(int TelemetryId)
        {
            return _rallyDbContext.Telemetry.Any(p => p.Id == TelemetryId);
        }

        public Telemetry Get(int TelemetryId)
        {
            return _rallyDbContext.Telemetry.FirstOrDefault(p => p.Id == TelemetryId);
        }

        public IEnumerable<Telemetry> GetAll()
        {
            return _rallyDbContext.Telemetry.ToList();
        }

        public IEnumerable<Telemetry> GetAllPerTeam(int teamId)
        {
            return _rallyDbContext.Telemetry.Where(t => t.Id == teamId).ToList();
        }

        public IEnumerable<Telemetry> GetAllTelemetry(DateTime hour)
        {
            return _rallyDbContext.Telemetry
                                  .Where(p => p.Date == hour)
                                  .ToList();
        }

        public void TelemetryAdd(Telemetry telemetry)
        {
            _rallyDbContext.Telemetry.Add(telemetry);
            _rallyDbContext.SaveChanges();
        }

        public void Update(Telemetry telemetry)
        {
            if(_rallyDbContext.Entry(telemetry).State == Microsoft.EntityFrameworkCore.EntityState.Detached)
            {
                _rallyDbContext.Attach(telemetry);
                _rallyDbContext.Entry(telemetry).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
            else
            {
                _rallyDbContext.Telemetry.Update(telemetry);
            }            
            _rallyDbContext.SaveChanges();
        }
    }
}
