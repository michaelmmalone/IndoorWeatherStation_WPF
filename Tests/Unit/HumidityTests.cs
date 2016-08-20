using FluentAssertions;
using IndoorWeatherStation_WPF.ApplicationModel;
using IndoorWeatherStation_WPF.DomainModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests.Helper;

namespace Tests.Unit
{
    [TestClass]

    public class HumidityTests
    {
        [TestMethod]
        public void HumidityConstructor_GivenAnIntValue_SetsValue()
        {
            // Arrange
            Humidity classUnderTest = new Humidity(56);

            // Act
            int result = classUnderTest.Value;

            // Assert
            result.Should().Be(56);
        }

        [TestMethod]
        public void Format_ValidHumidity_ReturnsHumidityAsStringWithDayOfWeek()
        {
            // Arrange
            Humidity classUnderTest = new Humidity(78);
            HumidityFormatter formatter = new HumidityFormatter();

            // Act
            string result = classUnderTest.Format(formatter);

            // Assert
            result.Should().Be("78%");
        }

        [TestMethod]
        public void HumidityEquality_SameTypeAndSameState_Equal()
        {
            EqualityTester.Act(54, 54, true);
        }

        [TestMethod]
        public void HumidityEquality_SameTypeAndDifferentState_NotEqual()
        {
            EqualityTester.Act(45, 34, false);
        }

        [TestMethod]
        public void HumidityEquality_DifferentType_NotEqual()
        {
            EqualityTester.Act(32, "a", false);
        }
    }
}
