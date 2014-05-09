using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vehicle.Concrete;
using Vehicle.Interfaces;

namespace Vehicle.Test
{
    public class TyrePressureSensorManager
    {
        private List<MonitoredTyre> _monitoredTyres = new List<MonitoredTyre>();

        public TyrePressureSensorManager(Tyres tyres, IAlarmListener listener)
        {
            foreach (var t in tyres)
            {                
                _monitoredTyres.Add(new MonitoredTyre(t.Value, listener));
            }
        }

        public void MonitorVehicleTyres()
        {
            foreach(MonitoredTyre t in _monitoredTyres)
            {
                t.InitialiseMonitoring();
            };
        }


    }
}
