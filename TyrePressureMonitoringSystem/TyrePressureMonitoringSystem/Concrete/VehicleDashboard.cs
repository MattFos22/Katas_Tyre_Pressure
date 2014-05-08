using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vehicle.Interfaces;
using Vehicle.Concrete;

namespace Vehicle.Concrete
{
    public class VehicleDashboard : IAlarmListener
    {
        public string messageToUser { get; private set; }
        public bool makeNoiseAtUser { get; private set; }

        public void AlarmTriggered(Alarm alarm)
        {
            messageToUser = string.Format("Current Psi of {0} exceeds thresholds set on date: {1}", alarm.RecordedPsi, alarm.DateOfAlarm);
            makeNoiseAtUser = true;
        }
    }
}
