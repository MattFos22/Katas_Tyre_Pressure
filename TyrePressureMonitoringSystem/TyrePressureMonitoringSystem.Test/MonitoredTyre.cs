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
        private TyrePressureSensor _sensor {get; set;}

        private readonly IAlarmListener _listener;
    
        public MonitoredTyre(Tyre tyre, TyrePressureSensor sensor, IAlarmListener listener)
	    {
            _tyre = tyre;
            _sensor = sensor;
            _listener = listener;
	    }

        public void InitialiseMonitoring()
        {
            _sensor.MonitorTyrePressure();
        }

        public void AlarmTriggered(TyrePressureAlarm alarm)
        {
            _listener.AlarmTriggered(alarm);  
        }

        public void AlarmTriggered(Alarm alarm)
        {
            throw new NotImplementedException();
        }
    }
}
