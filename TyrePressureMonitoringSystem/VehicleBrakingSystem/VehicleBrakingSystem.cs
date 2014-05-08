using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VehicleTyrePressureMonitoringSystem.Concrete;
using VehicleTyrePressureMonitoringSystem.Interfaces;

namespace VehicleBrakingSystem
{
    public class VehicleBrakingSystem : IAlarmListener
    {
        public bool EmergencyStop { get; private set; }
        public int BrakeForceApplied { get; private set; }

        public void AlarmTriggered(Alarm alarm)
        {
            EmergencyStop = true;
            BrakeForceApplied = 100;
        }
    }
}
