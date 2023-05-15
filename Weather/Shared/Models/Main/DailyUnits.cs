using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weather.Shared.Models.Main
{
    public class DailyUnits
    {
        public string? time { get; set; }

        public string? temperature_2m_max { get; set; }

        public string? temperature_2m_min { get; set; }

        public string? sunrise { get; set; }

        public string? sunset { get; set; }

        public string? uv_index_max { get; set; }

        public string? precipitation_hours  { get; set; }

        public string? windspeed_10m_max { get; set; }

    }
}
