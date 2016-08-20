using System;
using FluentAssertions;
using IndoorWeatherStation_WPF.ApplicationModel;
using IndoorWeatherStation_WPF.DomainModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests.Helper;

namespace Tests.Unit
{
    [TestClass]
    public class DateTests
    {
        [TestMethod]
        public void DateConstructor_GivenMonthDayYear_SetsValueToADateTimeObject()
        {
            // Arrange
            Date classUnderTest = new Date(3, 4, 2000);

            // Act
            DateTime result = classUnderTest.Value;

            // Assert
            result.Month.Should().Be(3);
            result.Day.Should().Be(4);
            result.Year.Should().Be(2000);
        }


        [TestMethod]
        public void Format_ValidDate_ReturnsDateAsStringWithDayOfWeek()
        {
            // Arrange
            Date classUnderTest = new Date(3, 4, 2000);
            DateFormatter formatter = new DateFormatter();

            // Act
            string result = classUnderTest.Format(formatter);

            // Assert
            result.Should().Be("Saturday  3/4/2000");
        }

        [TestMethod]
        public void DateEquality_SameTypeAndSameState_Equal()
        {
            EqualityTester.Act(new Date(3, 4, 2000), new Date(3, 4, 2000), true);
        }

        [TestMethod]
        public void DateEquality_SameTypeAndDifferentState_NotEqual()
        {
            EqualityTester.Act(new Date(3, 4, 2000), new Date(3, 14, 2000), false);
        }

        [TestMethod]
        public void DateEquality_DifferentType_NotEqual()
        {
            EqualityTester.Act(new Date(3, 4, 2000), "a", false);
        }
    }
}
