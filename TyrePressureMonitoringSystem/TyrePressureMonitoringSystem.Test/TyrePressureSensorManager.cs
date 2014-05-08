using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vehicle.Concrete;
using Vehicle.Interfaces;

namespace Vehicle.Test
{
    public class TyrePressureSensorManager:ITyrePressureAlarmListener
    {
        private List<MonitoredTyre> _monitoredTyres = new List<MonitoredTyre>();
        private readonly ITyrePressureAlarmListener _listener;

        public TyrePressureSensorManager(Tyres tyres, IAlarmListener listener)
        {
            foreach(Tyre t in tyres.)
            {
                _monitoredTyres.Add(new MonitoredTyre(t, new TyrePressureSensor(_listener),listener));
            }
        }

        public void MonitorVehicleTyres()
        {
            foreach(MonitoredTyre t in _monitoredTyres)
            {
                t.InitialiseMonitoring();
            };
        }

        public void AlarmTriggered(TyrePressureAlarm alarm)
        {
            
        }

    }
}
