using Vehicle.Concrete;
using Vehicle.Interfaces;

namespace Vehicle.Concrete
{
    public class VehicleBrakingSystem : IAlarmListener
    {
        public bool EmergencyStop { get; private set; }
        public int BrakeForceApplied { get; private set; }

        public void AlarmTriggered(Alarm alarm)
        {
            EmergencyStop = true;
            BrakeForceApplied = 100;
        }
    }
}
