using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weather.Shared.Models.Main
{
    public class Location
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string? City { get; set; }

        public string? Region { get; set; }
        public string? DisplayName { get; set; }
    }
}
