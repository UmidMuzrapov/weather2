using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weather.Shared.Models.Main
{
    public class WeatherHourly
    {
        public DateTime[]? time { get; set; }

        public float[]? temperature_2m { get; set; }

        public float[]? relativehumidity_2m { get; set; }

        public float[]? rain { get; set; }

        public float[]? snowfall { get; set; }
        
        public float[]? cloudcover { get; set; }

        public float[]? windspeed_10m { get; set; }

        public int[]? winddirection_10m { get; set; }

        public float[]? uv_index { get; set; }

        public bool[]? is_day { get; set; }
    }
}
