using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicle.Interfaces;

namespace Vehicle.Concrete
{
    public class AlarmPublisher : IAlarmListener
    {
        private List<IAlarmListener> _alarmSubscribers = new List<IAlarmListener>();

        public void AlarmTriggered(Alarm alarm)
        {
            _alarmSubscribers.ForEach(alarmSubscriber => alarmSubscriber.AlarmTriggered(alarm));
        }

        public void RegisterAlarmSubscriber(IAlarmListener alarmSubscriber)
        {
            _alarmSubscribers.Add(alarmSubscriber);
        }
    }
}
