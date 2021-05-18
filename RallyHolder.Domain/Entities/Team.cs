using System.Collections.Generic;
using System.Linq;

namespace RallyHolder.Domain.Entities
{
    public class Team
    {
        public int Id { get; set; }
        public string IdCode { get; set; }
        public string Name { get; set; }
        public int SeasonId { get; set; }
        public virtual Season Season { get; set; } //Not Recommended for big projects
        public ICollection<Pilot> Pilots { get; set; }
        public bool Validate()
        {
            if (string.IsNullOrEmpty(Name))
                return false;
            if(string.IsNullOrEmpty(IdCode))
                return false;

            return true;
        }
        public Team()
        {
            Pilots = new List<Pilot>();
        }

        public void AddPilot(Pilot pilot)
        {
            if(pilot != null && pilot.Validate())
            {
                if(!Pilots.Any(p => p.Id == pilot.Id))
                    Pilots.Add(pilot);
            }
        }

        public Pilot GetById(int id)
        {
            return Pilots.FirstOrDefault(e => e.Id == id);
        }
    }
}
