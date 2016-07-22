using IndoorWeatherStation_WPF.Adapters;
using IndoorWeatherStation_WPF.Ports;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests.BaseTestClasses;

namespace Tests.Component
{
    [TestClass]
    [Ignore] //TODO: service not working.
    public class WeatherStationTests : WeatherStationTestsBase
    {
        [TestMethod]
        [TestCategory("Component")]
        public override void MinuteChanged_RaisedWhenStartIsCalled()
        {
            base.MinuteChanged_RaisedWhenStartIsCalled();
        }

        [TestMethod]
        [TestCategory("Component")]
        public override void DayChanged_RaisedWhenStartIsCalled()
        {
            base.DayChanged_RaisedWhenStartIsCalled();
        }

        [TestMethod]
        [TestCategory("Component")]
        public override void OutdoorTemperatureyChanged_RaisedWhenStartIsCalled()
        {
            base.OutdoorTemperatureyChanged_RaisedWhenStartIsCalled();
        }

        [TestMethod]
        [TestCategory("Component")]
        public override void OutdoorHumidityChanged_RaisedWhenStartIsCalled()
        {
            base.OutdoorHumidityChanged_RaisedWhenStartIsCalled();
        }

        [TestMethod]
        [TestCategory("Component")]
        public override void IndoorTemperatureyChanged_RaisedWhenStartIsCalled()
        {
            base.IndoorTemperatureyChanged_RaisedWhenStartIsCalled();
        }

        [TestMethod]
        [TestCategory("Component")]
        public override void IndoorHumidityChanged_RaisedWhenStartIsCalled()
        {
            base.IndoorHumidityChanged_RaisedWhenStartIsCalled();
        }

        internal override IWeatherStation GetWeatherStation()
        {
            return new WeatherStation();
        }
    }
}
