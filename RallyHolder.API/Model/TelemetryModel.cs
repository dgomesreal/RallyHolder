using System;
using System.ComponentModel.DataAnnotations;

namespace RallyHolder.API.Model
{
    public class TelemetryModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Unidentified team")]
        public int TeamId { get; set; }

        [Required(ErrorMessage = "Team date was not received")]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Team time was not received")]
        public TimeSpan Hour { get; set; }

        public DateTime ServerDate { get; set; }
        public TimeSpan ServerHour { get; set; }

        [Required(ErrorMessage = "Latitude not reported")]
        public decimal Latitude { get; set; }

        [Required(ErrorMessage = "Longitude not reported")]
        public decimal Longitude { get; set; }

        [Required(ErrorMessage = "Fuel percentage not informed")]
        public decimal FuelPercentage { get; set; }

        [Required(ErrorMessage = "Speed ​​not reported")]
        public double Speed { get; set; }

        [Required(ErrorMessage = "RPM not reported")]
        public double RPM { get; set; }

        public int TemperatureExternal { get; set; }
        public int TemperatureEngine { get; set; }
        public double AltitudeLevelSea { get; set; }

        public bool PedalAccelerator { get; set; }
        public bool PedalBrake { get; set; }
    }
}
