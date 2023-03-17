using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACT.HueSync.Config.Model
{
    internal class ColorData
    {
        public string ColorId { get; set; }
        public string ZoneName { get; set; }
        public decimal StartTime { get; set; }
        public string WeatherId { get; set; }
    }
}
