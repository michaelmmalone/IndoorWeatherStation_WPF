using System;
using IndoorWeatherStation_WPF.ApplicationModel;
using Tests.Mocks;

namespace Tests.Fixtures
{
    internal class MinuteDayChangeMonitorFixture
    {
        private readonly IDateTimeSourceMock dateTimeSourceMock;

        public MinuteDayChangeMonitorFixture()
        {
            dateTimeSourceMock = IDateTimeSourceMock.Create();

            IMinuteDayChangeMonitorStrategyMock minuteDayChangeMonitorStrategy =
                IMinuteDayChangeMonitorStrategyMock.Create();

            this.Target = new MinuteDayChangeMonitor(
                dateTimeSourceMock,
                minuteDayChangeMonitorStrategy);
        }

        public MinuteDayChangeMonitor Target { get; private set; }

        public void DateAndTimeValues(params DateTime[] dateTimeValues)
        {
            dateTimeSourceMock.NowReturnValues(dateTimeValues);
        }
    }
}
