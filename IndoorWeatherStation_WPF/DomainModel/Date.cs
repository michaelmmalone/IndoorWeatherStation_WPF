using System;
using IndoorWeatherStation_WPF.ApplicationModel;

namespace IndoorWeatherStation_WPF.DomainModel
{
    internal class Date : IEquatable<Date>
    {
        public Date(int month, int day, int year)
        {
            this.Value = new DateTime(year, month, day);
        }

        public DateTime Value { get; private set; }

        public string Format(DateFormatter formatter)
        {
            return formatter.Format(this.Value);
        }

        #region Equality

        public override bool Equals(object obj)
        {
            return this.Equals(obj as Date);
        }

        public bool Equals(Date other)
        {
            if (Object.ReferenceEquals(null, other)) return false;
            if (Object.ReferenceEquals(this, other)) return true;
            return this.Value.Equals(other.Value);
        }

        public override int GetHashCode()
        {
            return this.Value.GetHashCode();
        }

        public static bool operator ==(Date left, Date right)
        {
            return Object.Equals(left, right);
        }

        public static bool operator !=(Date left, Date right)
        {
            return !Object.Equals(left, right);
        }

        #endregion Equality

    }
}