using System;
using FluentAssertions;
using IndoorWeatherStation_WPF.ApplicationModel;
using IndoorWeatherStation_WPF.DomainModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests.Helper;

namespace Tests.Unit
{
    [TestClass]
    public class TimeTests
    {
        [TestMethod]
        public void TimeConstructor_GivenHourAndMinute_SetsValueToADateTimeObject()
        {
            // Arrange
            Time classUnderTest = new Time(3, 14);

            // Act
            DateTime result = classUnderTest.Value;

            // Assert
            result.Hour.Should().Be(3);
            result.Minute.Should().Be(14);
        }

        [TestMethod]
        public void Format_ValidTime_ReturnsTimeAsStringWithHourAndMinute()
        {
            // Arrange
            Time classUnderTest = new Time(3, 14);
            TimeFormatter formatter = new TimeFormatter();

            // Act
            string result = classUnderTest.Format(formatter);

            // Assert
            result.Should().Be("3:14");
        }

        [TestMethod]
        public void TimeEquality_SameTypeAndSameState_Equal()
        {
            EqualityTester.Act(new Time(10, 30), new Time(10, 30), true);
        }

        [TestMethod]
        public void TimeEquality_SameTypeAndDifferentState_NotEqual()
        {
            EqualityTester.Act(new Time(10, 30), new Time(4, 30), false);
        }

        [TestMethod]
        public void TimeEquality_DifferentType_NotEqual()
        {
            EqualityTester.Act(new Time(10, 30), "a", false);
        }
    }
}
