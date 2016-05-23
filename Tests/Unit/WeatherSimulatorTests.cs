using IndoorWeatherStation_WPF.Ports;
using IndoorWeatherStation_WPF.Simulators;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests.BaseTestClasses;

namespace Tests.Unit
{
    [TestClass]
    public class WeatherSimulatorTests : WeatherTestsBase
    {
        [TestMethod]
        [TestCategory("Unit")]
        public override void GetWeatherAsync_ReturnsGoodValues()
        {
            base.GetWeatherAsync_ReturnsGoodValues();
        }

        internal override IWeather GetWeather()
        {
            return new WeatherSimulator();
        }
    }
}
