using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicle.Concrete
{
    public class Alarm
    {
        public DateTime DateOfAlarm { get; set; }
        public string OriginationOfAlarm { get; set; }
        public string Message { get; set; }
    }
}
