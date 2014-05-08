﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vehicle.Concrete;
using Vehicle.Interfaces;

namespace TyrePressureMonitoringSystem.Test
{
    public class MockAlarmListener:IAlarmListener
    {
        public bool AlarmTriggeredCalled { get; private set; }

        public void AlarmTriggered(Alarm alarm)
        {
            AlarmTriggeredCalled = true;
        }
    }
}
