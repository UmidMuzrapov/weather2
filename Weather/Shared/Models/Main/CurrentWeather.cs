using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weather.Shared.Models.Main
{
    public class CurrentWeather
    {
        public float temperature { get; set; }
        public float windspeed { get; set; }
        public float winddirection { get; set; }
        public float windcode { get; set; }
        public bool is_day { get; set; }
        public string? time { get; set; }
    }
}
