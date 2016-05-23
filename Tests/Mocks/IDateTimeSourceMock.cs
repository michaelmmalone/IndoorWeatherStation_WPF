using System;
using IndoorWeatherStation_WPF.Ports;

namespace Tests.Mocks
{
    internal class IDateTimeSourceMock : IDateTimeSource
    {
        private DateTime now = DateTime.MaxValue;
        private DateTime[] nowReturnValues;
        private int nextNowReturnValue;

        public static IDateTimeSourceMock Create()
        {
            return new IDateTimeSourceMock();
        }

        private IDateTimeSourceMock()
        {
        }

        public void NowReturnValues(params DateTime[] nowReturnValues)
        {
            this.nextNowReturnValue = 0;
            this.nowReturnValues = nowReturnValues;
        }

        #region IDateTimeSource

        public DateTime Now
        {
            get
            {
                return this.ReturnNextNowValue();
            }

            private set
            {
                this.now = value;
            }
        }

        #endregion

        private DateTime ReturnNextNowValue()
        {
            if (this.now != DateTime.MaxValue)
            {
                return this.now;
            }

            return this.nowReturnValues[Math.Min(
                this.nowReturnValues.Length - 1, 
                this.nextNowReturnValue++)];
        }
    }
}
