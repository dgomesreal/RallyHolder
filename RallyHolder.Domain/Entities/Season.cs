using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RallyHolder.Domain.Entities
{
    public class Season
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime BeginningDate { get; set; }
        public DateTime? EndDate { get; set; }
        public ICollection<Team> Teams { get; set; }
    }
}
