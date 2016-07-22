using IndoorWeatherStation_WPF.Adapters;
using IndoorWeatherStation_WPF.Ports;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests.BaseTestClasses;

namespace Tests.Component
{
    [TestClass]
    public class CdyneWeatherTests : WeatherTestsBase
    {
        [TestMethod]
        [Ignore] //TODO: service not working.
        [TestCategory("Component")]
        public override void GetWeatherAsync_ReturnsGoodValues()
        {
            base.GetWeatherAsync_ReturnsGoodValues();
        }

        internal override IWeather GetWeather()
        {
            return new CdyneWeatherAdapter();
        }
    }
}
