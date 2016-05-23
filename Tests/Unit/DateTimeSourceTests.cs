using System;
using FluentAssertions;
using IndoorWeatherStation_WPF.Adapters;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Unit
{
    [TestClass]
    public class DateTimeSourceTests
    {
        [TestMethod]
        [TestCategory("Unit")]
        public void Now_ReturnsCurrentDateAndTime()
        {
            // Arrange
            DateTimeSource target = new DateTimeSource();

            // Act
            DateTime result = target.Now;

            // Assert
            DateTime expected = DateTime.Now;

            result.Minute.Should().Be(expected.Minute);
            result.Hour.Should().Be(expected.Hour);
            result.Day.Should().Be(expected.Day);
            result.Month.Should().Be(expected.Month);
        }
    }
}
