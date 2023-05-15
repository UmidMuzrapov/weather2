using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weather.Shared.Models.Main
{
    public class HourlyUnits
    {
        public string? time { get; set; }

        public string? temperature_2m { get; set; }

        public string? relativehumidity_2m { get; set; }

        public string? rain { get; set; }

        public string? snowfall { get; set; }

        public string? cloudcover { get; set; }

        public string? windspeed_10m { get; set; }

        public string? winddirection_10m { get; set; }

        public string? uv_index { get; set; }

        public string? is_day { get; set; }
    }
}
