using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vehicle.Interfaces
{
    public interface ISensor
    {
        int thresholdMax { get; set; }
        int thresholdMin { get; set; }

        bool MonitorTemperatures();
    }
}
