using RallyHolder.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
