using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vehicle.Concrete;
using Vehicle.Interfaces;

namespace Vehicle.Test
{
    public class MockTyrePressureAlarmListener:ITyrePressureAlarmListener
    {
        private bool _alarmTriggered;

        public void TyrePressureAlarmTriggered(TyrePressureAlarm alarm)
        {
            _alarmTriggered = true;
        }
    }
}
