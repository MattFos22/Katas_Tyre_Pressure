using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TyrePressureMonitoringSystem.Test
{
    public interface IAlarmListener
    {
        void AlarmTriggered(Alarm alarm);
    }
}
