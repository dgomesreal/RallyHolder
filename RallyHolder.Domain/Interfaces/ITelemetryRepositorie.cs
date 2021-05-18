using RallyHolder.Domain.Entities;
using System.Collections.Generic;

namespace RallyHolder.Domain.Interfaces
{
    public interface ITelemetryRepositorie
    {
        void TelemetryAdd(Telemetry telemetry);
        IEnumerable<Telemetry> GetAll();
        IEnumerable<Telemetry> GetAllPerTeam(int teamId);
        Telemetry Get(int TelemetryId);
        bool Exists(int TelemetryId);
        void Update(Telemetry telemetry);
        void Delete(Telemetry telemetry);
    }
}
