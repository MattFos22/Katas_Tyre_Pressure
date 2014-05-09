using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;
using Vehicle.Concrete;

namespace Vehicle.Test
{
    [TestClass]
    public class TyrePressureMonitoringSystemTests
    {
        [TestMethod]
        public void AlarmFiresWhenTyrePressureFallsOutOfSetRange()
        {

            var alarmListener = new MockAlarmListener();

            Tyres tyres = createVehicleTyres();

            TyrePressureSensorManager tyrePressureManager = new TyrePressureSensorManager(tyres, alarmListener);

            tyrePressureManager.MonitorVehicleTyres();

            Assert.IsTrue(alarmListener.AlarmTriggeredCalled, "alarm triggered");
        }

        private Tyres createVehicleTyres()
        {
            var tyres = new Tyres();
            tyres.Add("Front DS", new Tyre() { maxPsi = 40, minPsi = 10 });
            tyres.Add("Front PS", new Tyre() { maxPsi = 40, minPsi = 10 });
            tyres.Add("Rear DS", new Tyre() { maxPsi = 35, minPsi = 10 });
            tyres.Add("Rear PS", new Tyre() { maxPsi = 35, minPsi = 10 });

            return tyres;
        }

        [TestMethod]
        public void VehicleNotifiesDashboardOfCurrentTyrePressure()
        {
            var tyrePressureDashboard = new VehicleDashboard();

            Tyres tyres = createVehicleTyres();

            TyrePressureSensorManager tyrePressureManager = new TyrePressureSensorManager(tyres, tyrePressureDashboard);

            tyrePressureManager.MonitorVehicleTyres();

            Assert.IsNotNull(tyrePressureDashboard.messageToUser);
            Assert.IsTrue(tyrePressureDashboard.makeNoiseAtUser);
        }

        [TestMethod]
        public void VehicleAppliesBrakesWhenAlarmSounds()
        {
            var vehicleBrakingSystem = new VehicleBrakingSystem();
            Tyres tyres = createVehicleTyres();

            TyrePressureSensorManager tyrePressureManager = new TyrePressureSensorManager(tyres, vehicleBrakingSystem);

            tyrePressureManager.MonitorVehicleTyres();

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

            Tyres tyres = createVehicleTyres();

            TyrePressureSensorManager tyrePressureManager = new TyrePressureSensorManager(tyres, tyrePressureAlarmPublisher);

            tyrePressureManager.MonitorVehicleTyres();

            Assert.IsTrue(vehicleBrakingSystem.EmergencyStop);
            Assert.AreEqual<int>(100, vehicleBrakingSystem.BrakeForceApplied);
            Assert.IsNotNull(vehicleDashboard.messageToUser);
            Assert.IsTrue(vehicleDashboard.makeNoiseAtUser);
        }

      //  [TestMethod]
      //  public void VehicleReportsWhichTyreAlarmHasBeenTriggeredBy()
      //  {
      //      var vehicleDashboard = new VehicleDashboard();
      //      var tyre = new Tyre();

      //      var sensor = new TyrePressureSensor(tyrePressureAlarmPublisher)
      //      {
      //          thresholdMax = 20,
      //          thresholdMin = 5
      //      };



      //  }

        [TestMethod]
        public void VehicleCanMonitorPressureOnIndividualTyres()
        {

            var mockAlarmListener = new MockAlarmListener();

            var monitoredTyre = new MonitoredTyre(new Tyre(), mockAlarmListener);

            Thread t = new Thread(new ThreadStart(monitoredTyre.InitialiseMonitoring));
            t.Start();

            int currentPressure = monitoredTyre.GetCurrentPressure();

            Assert.IsNotNull(monitoredTyre.GetCurrentPressure());
            Assert.IsTrue(mockAlarmListener.AlarmTriggeredCalled);


        }



    }
}
