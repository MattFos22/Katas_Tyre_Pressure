using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TyrePressureMonitoringSystem.Test
{
    public class AlarmPublisher : IAlarmListener
    {

        private List<IAlarmListener> _alarmSubscribers = new List<IAlarmListener>();

        public void AlarmTriggered(Alarm alarm)
        {
            _alarmSubscribers.ForEach(alarmSubscriber => alarmSubscriber.AlarmTriggered(alarm));
        }
    }
}
