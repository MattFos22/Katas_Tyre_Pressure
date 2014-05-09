using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vehicle.Concrete;
using Vehicle.Interfaces;

namespace Vehicle.Interfaces
{
    public interface ITyrePressureAlarmListener
    {
        void TyrePressureAlarmTriggered(TyrePressureAlarm alarm);
    }
}
