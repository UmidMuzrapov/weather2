using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weather.Shared.Models.Main
{
    public class Weather
    {
        public CurrentWeather? CurrentWeather { get; set; }
        public DailyUnits? DailyUnits { get; set; }
        public HourlyUnits? HourlyUnits { get; set; }
        public WeatherDaily? WeatherDaily { get; set; }
        public WeatherHourly? WeatherHourly { get; set; }

    }
}
