using System;
using IndoorWeatherStation_WPF.ApplicationModel;

namespace IndoorWeatherStation_WPF.DomainModel
{
    internal class Time : IEquatable<Time>
    {
        public Time(int hour, int minute)
        {
            this.Value = new DateTime(2000, 1, 1, hour, minute, 0);
        }

        public DateTime Value { get; private set; }

        public string Format(TimeFormatter formatter)
        {
            return formatter.Format(this.Value);
        }

        public override bool Equals(object obj)
        {
            return this.Equals(obj as Time);
        }

        public bool Equals(Time other)
        {
            if (Object.ReferenceEquals(null, other)) return false;
            if (Object.ReferenceEquals(this, other)) return true;
            return this.Value.Equals(other.Value);
        }

        public override int GetHashCode()
        {
            return this.Value.GetHashCode();
        }

        public static bool operator ==(Time left, Time right)
        {
            return Object.Equals(left, right);
        }

        public static bool operator !=(Time left, Time right)
        {
            return !Object.Equals(left, right);
        }
    }
}