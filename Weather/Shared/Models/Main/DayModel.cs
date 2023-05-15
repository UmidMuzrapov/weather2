using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weather.Shared.Models.Main
{
    public class DayModel
    {
        public DateTime time { get; set; }
        public float temperature_2m_max { get; set; }
        public float temperature_2m_min { get; set; }
        public DateTime sunrise { get; set; }
        public DateTime sunset { get; set; }
        public float uv_index { get; set; }
        public float precipitation_hours { get; set; }
        public float windspeed_10m_max { get; set; }
      
    }
}
