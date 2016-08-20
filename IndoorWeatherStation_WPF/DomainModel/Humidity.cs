using System;
using IndoorWeatherStation_WPF.ApplicationModel;

namespace IndoorWeatherStation_WPF.DomainModel
{
    internal class Humidity : IEquatable<Humidity>
    {
        public Humidity(int humidity)
        {
            this.Value = humidity;
        }

        public int Value { get; private set; }

        public string Format(HumidityFormatter formatter)
        {
            return formatter.Format(this.Value);
        }

        #region Equality

        public override bool Equals(object obj)
        {
            return this.Equals(obj as Humidity);
        }

        public bool Equals(Humidity other)
        {
            if (Object.ReferenceEquals(null, other)) return false;
            if (Object.ReferenceEquals(this, other)) return true;
            return this.Value == other.Value;
        }

        public override int GetHashCode()
        {
            return this.Value;
        }

        public static bool operator ==(Humidity left, Humidity right)
        {
            return Object.Equals(left, right);
        }

        public static bool operator !=(Humidity left, Humidity right)
        {
            return !Object.Equals(left, right);
        }

        #endregion Equality
    }
}