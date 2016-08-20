using System;

namespace IndoorWeatherStation_WPF.DomainModel
{
    internal class Temperature : IEquatable<Temperature>
    {
        public Temperature(int temperature)
        {
            this.Value = temperature;
        }

        public int Value { get; private set; }

        #region Equality

        public override bool Equals(object obj)
        {
            return this.Equals(obj as Temperature);
        }

        public bool Equals(Temperature other)
        {
            if (Object.ReferenceEquals(null, other)) return false;
            if (Object.ReferenceEquals(this, other)) return true;
            return this.Value == other.Value;
        }

        public override int GetHashCode()
        {
            return this.Value.GetHashCode();
        }

        public static bool operator ==(Temperature left, Temperature right)
        {
            return object.Equals(left, right);
        }

        public static bool operator !=(Temperature left, Temperature right)
        {
            return !object.Equals(left, right);
        }

        #endregion Equality
    }
}
