using FluentAssertions;
using IndoorWeatherStation_WPF.ApplicationModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Unit
{
    [TestClass]
    public class HumidityFormatterTests
    {
        [TestMethod]
        [TestCategory("Unit")]
        public void Format_ReturnsStringWithPercentSignAppendedToHumidity()
        {
            // Arrange
            HumidityFormatter target = new HumidityFormatter();

            // Act
            string result = target.Format(72);

            // Assert
            result.Should().Be("72%");
        }
    }
}
