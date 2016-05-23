using System;
using FluentAssertions;
using IndoorWeatherStation_WPF.ApplicationModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Unit
{
    [TestClass]
    public class TimeFormatterTests
    {
        [TestMethod]
        [TestCategory("Unit")]
        public void Format_ReturnsStringWithHourAndMinuteOnly()
        {
            // Arrange
            TimeFormatter target = new TimeFormatter();

            // Act
            string result = target.Format(new DateTime(2015, 10, 12, 9, 20, 0));

            // Assert
            result.Should().Be("9:20");
        }
    }
}
