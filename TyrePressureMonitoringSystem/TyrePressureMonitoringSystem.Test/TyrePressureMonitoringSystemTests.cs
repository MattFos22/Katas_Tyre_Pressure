using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TyrePressureMonitoringSystem;

namespace TyrePressureMonitoringSystem.Test
{
    [TestClass]
    public class TyrePressureMonitoringSystemTests
    {
        [TestMethod]
        public void AlarmFiresWhenTyrePressureFallsOutOfSetRange()
        {

            var alarmListener = new MockAlarmListener();

            var sensor = new FakeSensor(alarmListener)
                {
                    thresholdMax = 20,
                    thresholdMin = 5
                };

            sensor.MonitorTemperatures();
            Assert.IsTrue(alarmListener.AlarmTriggeredCalled, "alarm triggered");
        }



        [TestMethod]
        public void AlarmFiresAndNotifiesDashboardOfCurrentTyrePressure()
        {
            var tyrePressureDashboard = new TyrePressureDashboard();

            var sensor = new FakeSensor(tyrePressureDashboard)
            {
                thresholdMax = 20,
                thresholdMin = 5
            };

            sensor.MonitorTemperatures();

            Assert.IsNotNull(tyrePressureDashboard.messageToUser);
            Assert.IsTrue(tyrePressureDashboard.makeNoiseAtUser);
        }

        [TestMethod]
        public void VehicleAppliesBrakesWhenAlarmSounds()
        {
            
        }

    }
}
