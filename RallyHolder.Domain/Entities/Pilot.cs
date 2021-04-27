using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RallyHolder.Domain.Entities
{
    public class Pilot
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TeamId { get; set; }
        public virtual Team Team { get; set; } //Not recommended for big projects

    }
}
