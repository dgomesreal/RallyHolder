using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RallyHolder.Domain.Entities
{
    public class Telemetry
    {
        public int Id { get; set; }
        public int SeasonId { get; set; }
        public int PilotId { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Hour { get; set; }
        public decimal Latidude { get; set; }
        public decimal Longitude { get; set; }
        public decimal FuelPercentage { get; set; }
        public decimal Speed { get; set; }
        public decimal RPM { get; set; }
        public int ExternalTemperature { get; set; }
        public int InternalTemperature { get; set; }
        public double SeaAltitude { get; set; }
        public bool AcceleratorPedal { get; set; }
        public bool BrakePedal { get; set; }

    }
}
