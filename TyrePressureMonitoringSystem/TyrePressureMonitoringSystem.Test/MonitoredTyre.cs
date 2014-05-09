using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vehicle.Concrete;
using Vehicle.Interfaces;

namespace Vehicle.Test
{
    public class MonitoredTyre : ITyrePressureAlarmListener
    {
        private Tyre _tyre {get; set;}
        private TyrePressureSensor _sensor {get;set;}

        private readonly IAlarmListener _listener;
    
        public MonitoredTyre(Tyre tyre, IAlarmListener listener)
	    {
            _tyre = tyre;
            _sensor = new TyrePressureSensor(this);
            _listener = listener;
	    }

        public void InitialiseMonitoring()
        {
            _sensor.MonitorTyrePressure();
        }

        public void TyrePressureAlarmTriggered(TyrePressureAlarm alarm)
        {
            _listener.AlarmTriggered(alarm);  
        }

        public int GetCurrentPressure()
        {
            return _sensor.pressureCurrent;
        }

    }
}
