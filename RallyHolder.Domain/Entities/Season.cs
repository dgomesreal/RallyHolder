using System;
using System.Collections.Generic;

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
            if(team != null)
            {
                if (!string.IsNullOrEmpty(team.Name))
                {
                    Teams.Add(team);
                }
                
            }
        }
    }
}
