using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weather.Shared.Models.Main
{
    public class Weather
    {
        public Weather(Dictionary<int, WeatherHourly> hourlyInfo, WeatherDaily dailyInfo)
        {
            this.DailyInfo=dailyInfo;
            this.HourlyInfo=hourlyInfo;
        }

        public WeatherDaily DailyInfo { get; set; }
        public Dictionary<int, WeatherHourly> HourlyInfo { get; set; }
    }
}
