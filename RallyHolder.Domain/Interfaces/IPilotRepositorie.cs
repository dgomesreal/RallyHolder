using RallyHolder.Domain.Entities;
using System.Collections.Generic;

namespace RallyHolder.Domain.Interfaces
{
    public interface IPilotRepositorie
    {
        void Add(Pilot pilot);
        IEnumerable<Pilot> GetAll();
        Pilot Get(int pilotId);
        bool Exist(int pilotId);
        void Update(Pilot pilot);
        void Delete(Pilot pilot);
    }
}
