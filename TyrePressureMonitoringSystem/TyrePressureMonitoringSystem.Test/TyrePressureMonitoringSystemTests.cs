using Microsoft.VisualStudio.TestTools.UnitTesting;
using Vehicle.Concrete;

namespace TyrePressureMonitoringSystem.Test
{
    [TestClass]
    public class TyrePressureMonitoringSystemTests
    {
        [TestMethod]
        public void AlarmFiresWhenTyrePressureFallsOutOfSetRange()
        {

            var alarmListener = new MockAlarmListener();

            var sensor = new TyrePressureSensor(alarmListener)
                {
                    thresholdMax = 20,
                    thresholdMin = 5
                };

            sensor.MonitorTyrePressure();
            Assert.IsTrue(alarmListener.AlarmTriggeredCalled, "alarm triggered");
        }



        [TestMethod]
        public void VehicleNotifiesDashboardOfCurrentTyrePressure()
        {
            var tyrePressureDashboard = new VehicleDashboard();

            var sensor = new TyrePressureSensor(tyrePressureDashboard)
            {
                thresholdMax = 20,
                thresholdMin = 5
            };

            sensor.MonitorTyrePressure();

            Assert.IsNotNull(tyrePressureDashboard.messageToUser);
            Assert.IsTrue(tyrePressureDashboard.makeNoiseAtUser);
        }

        [TestMethod]
        public void VehicleAppliesBrakesWhenAlarmSounds()
        {
            var vehicleBrakingSystem = new VehicleBrakingSystem();

            var sensor = new TyrePressureSensor(vehicleBrakingSystem)
            {
                thresholdMax = 20,
                thresholdMin = 5
            };

            sensor.MonitorTyrePressure();

            Assert.IsTrue(vehicleBrakingSystem.EmergencyStop);
            Assert.AreEqual<int>(100,vehicleBrakingSystem.BrakeForceApplied);

        }

        [TestMethod]
        public void VehicleAppliesBrakesAndNotifiesDashboardOfCurrentTyrePressureWhenAlarmSounds()
        {
            var vehicleBrakingSystem = new VehicleBrakingSystem();
            var vehicleDashboard = new VehicleDashboard();

            var tyrePressureAlarmPublisher = new AlarmPublisher();

            tyrePressureAlarmPublisher.RegisterAlarmSubscriber(vehicleBrakingSystem);
            tyrePressureAlarmPublisher.RegisterAlarmSubscriber(vehicleDashboard);

            var sensor = new TyrePressureSensor(tyrePressureAlarmPublisher)
            {
                thresholdMax = 20,
                thresholdMin = 5
            };

            sensor.MonitorTyrePressure();

            Assert.IsTrue(vehicleBrakingSystem.EmergencyStop);
            Assert.AreEqual<int>(100, vehicleBrakingSystem.BrakeForceApplied);
            Assert.IsNotNull(vehicleDashboard.messageToUser);
            Assert.IsTrue(vehicleDashboard.makeNoiseAtUser);
        }

        [TestMethod]
        public void VehicleReportsWhichTyreAlarmHasBeenTriggeredBy()
        {
            var vehicleDashboard = new VehicleDashboard();

            var sensor = new TyrePressureSensor(tyrePressureAlarmPublisher)
            {
                thresholdMax = 20,
                thresholdMin = 5
            };
        }

    }
}
