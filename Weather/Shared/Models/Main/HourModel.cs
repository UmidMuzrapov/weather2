using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weather.Shared.Models.Main
{
    public class HourModel
    {
        public DateTime Time { get; set; }

        public float Temperature2M { get; set; }

        public float RelativeHumidity { get; set; }

        public float Rain { get; set; }

        public float Snowfall { get; set; }

        public float CloudCover { get; set; }

        public int WindDirection { get; set; }

        public float UVIndex { get; set; }

        public bool IsDay { get; set; }
    }
}
