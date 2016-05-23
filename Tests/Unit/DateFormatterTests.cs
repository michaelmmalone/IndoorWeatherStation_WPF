using System;
using FluentAssertions;
using IndoorWeatherStation_WPF.ApplicationModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Unit
{
    [TestClass]
    public class DateFormatterTests
    {
        [TestMethod]
        [TestCategory("Unit")]
        public void Format_ReturnsNameOfDayFollowedByDate()
        {
            // Arrange
            DateFormatter target = new DateFormatter();

            // Act
            string result = target.Format(new DateTime(2015, 10, 12));

            // Assert
            result.Should().Be("Monday  10/12/2015");
        }
    }
}
