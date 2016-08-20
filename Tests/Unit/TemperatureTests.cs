using FluentAssertions;
using IndoorWeatherStation_WPF.DomainModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests.Helper;

namespace Tests.Unit
{
    [TestClass]
    public class TemperatureTests
    {
        [TestMethod]
        public void TemperatureConstructor_GivenAnIntValue_SetsValue()
        {
            // Arrange
            Temperature classUnderTest = new Temperature(56);

            // Act
            int result = classUnderTest.Value;

            // Assert
            result.Should().Be(56);
        }

        [TestMethod]
        public void TemperatureEquality_SameTypeAndSameState_Equal()
        {
            EqualityTester.Act(54, 54, true);
        }

        [TestMethod]
        public void TemperatureEquality_SameTypeAndDifferentState_NotEqual()
        {
            EqualityTester.Act(45, 34, false);
        }

        [TestMethod]
        public void TemperatureEquality_DifferentType_NotEqual()
        {
            EqualityTester.Act(32, "a", false);
        }
    }
}
