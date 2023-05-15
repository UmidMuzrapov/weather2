using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weather.Shared.Models.Main
{
    public class WeatherDaily
    {
        public double MaximumTemperature { get; set; }

        public double MinimumTemperature { get; set; }

        public string Sunrise { get; set; }

        public string Sunset { get; set;}

        public double UVIndexMax { get; set; }

    }
}
