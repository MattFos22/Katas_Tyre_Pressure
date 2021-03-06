﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vehicle.Interfaces;
using Vehicle.Concrete;

namespace Vehicle.Concrete
{
    public class TyrePressureSensor
    {
        public int thresholdMax { get; set; }
        public int thresholdMin { get; set; }
        public int pressureCurrent { get; set; }

        private readonly ITyrePressureAlarmListener _listener;

        public TyrePressureSensor(ITyrePressureAlarmListener listener)
        {
            _listener = listener;
        }

        public void MonitorTyrePressure()
        {
            var random = new Random();
            while(1==1)
            {
               var pressureCurrent = random.Next(1, 9999);
               
               if(pressureCurrent >= thresholdMax | pressureCurrent <= thresholdMin) // if alarm sounded
               {
                   var alarm = new TyrePressureAlarm(pressureCurrent);
                   _listener.TyrePressureAlarmTriggered(alarm);
                   break;
               }
            }
        }
    }
}
