using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vehicle.Concrete
{
    public class Alarm
    {
        public int RecordedPsi { get; set; }
        public DateTime DateOfAlarm { get; set; }

        public Alarm(int psi)
        {
            RecordedPsi = psi;
            DateOfAlarm = DateTime.Now;
        }
    }
}
