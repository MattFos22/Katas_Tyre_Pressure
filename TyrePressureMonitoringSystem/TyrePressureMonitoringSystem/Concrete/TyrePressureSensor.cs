using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vehicle.Interfaces;

namespace Vehicle.Concrete
{
    public class TyrePressureSensor
    {
        public int thresholdMax { get; set; }
        public int thresholdMin { get; set; }
        
        private readonly IAlarmListener _listener;

        public TyrePressureSensor(IAlarmListener listener)
        {
            _listener = listener;
        }

        public void MonitorTyrePressure()
        {
            var random = new Random();
            while(1==1)
            {
               var randomNumber = random.Next(4, 30);
               if(randomNumber >= thresholdMax | randomNumber <= thresholdMin) // if alarm sounded
               {
                   var alarm = new Alarm(randomNumber);
                   _listener.AlarmTriggered(alarm);
                   break;
               }
            }
        }
    }
}
