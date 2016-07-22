using IndoorWeatherStation_WPF.Ports;
using IndoorWeatherStation_WPF.Simulators;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests.BaseTestClasses;

namespace Tests.Unit
{
    [TestClass]
    public class WeatherStationSimulatorTests : WeatherStationTestsBase
    {
        //TODO: try putting in base!
        [TestMethod]
        [TestCategory("Unit")]
        public override void MinuteChanged_RaisedWhenStartIsCalled()
        {
            base.MinuteChanged_RaisedWhenStartIsCalled();
        }

        [TestMethod]
        [TestCategory("Unit")]
        public override void DayChanged_RaisedWhenStartIsCalled()
        {
            base.DayChanged_RaisedWhenStartIsCalled();
        }

        [TestMethod]
        [TestCategory("Unit")]
        public override void OutdoorTemperatureyChanged_RaisedWhenStartIsCalled()
        {
            base.OutdoorTemperatureyChanged_RaisedWhenStartIsCalled();
        }

        [TestMethod]
        [TestCategory("Unit")]
        public override void OutdoorHumidityChanged_RaisedWhenStartIsCalled()
        {
            base.OutdoorHumidityChanged_RaisedWhenStartIsCalled();
        }

        [TestMethod]
        [TestCategory("Unit")]
        public override void IndoorTemperatureyChanged_RaisedWhenStartIsCalled()
        {
            base.IndoorTemperatureyChanged_RaisedWhenStartIsCalled();
        }

        [TestMethod]
        [TestCategory("Unit")]
        public override void IndoorHumidityChanged_RaisedWhenStartIsCalled()
        {
            base.IndoorHumidityChanged_RaisedWhenStartIsCalled();
        }

        internal override IWeatherStation GetWeatherStation()
        {
            return new WeatherStationSimulator();
        }
    }
}
