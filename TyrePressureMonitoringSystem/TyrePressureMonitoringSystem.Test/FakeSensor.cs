using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TyrePressureMonitoringSystem.Test
{
    public class FakeSensor
    {
        public int thresholdMax { get; set; }
        public int thresholdMin { get; set; }
        
        private readonly IAlarmListener _listener;

        public FakeSensor(IAlarmListener listener)
        {
            _listener = listener;
        }

        public void MonitorTemperatures()
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
