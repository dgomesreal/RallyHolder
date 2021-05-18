using System;
using System.Collections.Generic;
using System.Linq;

namespace RallyHolder.Domain.Entities
{
    public class Season
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime BeginningDate { get; set; }
        public DateTime? EndDate { get; set; }
        public virtual ICollection<Team> Teams { get; set; }
        public Season()
        {
            Teams = new List<Team>();
        }
        public void AddTeam(Team team)
        {
            //conditions
            if(team != null && team.Validate())
            {
                if (!Teams.Any(e => e.Id == team.Id))
                {
                    Teams.Add(team);
                }
                
            }
        }
        public Team GetById(int id)
        {
            return Teams.FirstOrDefault(e => e.Id == id);
        }

    }
}
