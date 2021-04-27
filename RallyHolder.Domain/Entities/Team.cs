using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
