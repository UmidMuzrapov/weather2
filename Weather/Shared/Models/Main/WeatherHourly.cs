using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weather.Shared.Models.Main
{
    public class WeatherHourly
    {

        public WeatherHourly(string hour, double temperature, double relativeHumidity, 
            double precipitation_probability, double precipitation, int cloudcover, double windspeed)
        {
            this.Hour = hour;
            this.Temperature = temperature;
            this.RelativeHumidity= relativeHumidity;
            this.Cloudcover = cloudcover;
            this.Windspeed = windspeed;
            this.Precipitation= precipitation;
            this.Precipitation_probability= precipitation_probability;
        }

        public string Hour { get; set; }
        public double Temperature { get; set; } = 0.0;      
        public double RelativeHumidity { get;set; }
        public double Precipitation_probability { get;set; }
        public double Precipitation { get; set;}
        public int Cloudcover { get; set; }
        public double Windspeed { get; set; }

    }
}
