using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab12
{
    abstract class Vehicle : ICloneable, IComparable
    {
        private int cost;
        public int Cost
        {
            get => cost;
            set => cost = value < 0 ? throw new Exception("Cost can't be negative value") : value;
        }

        private int speed;
        public int Speed
        {
            get => speed;
            set => speed = value < 0 ? throw new Exception("Speed can't be negative value") : value;
        }

        private int year;
        public int Year
        {
            get => year;
            set => year = value < 950 ? throw new Exception("Year is too low") : value;
        }

        protected Vehicle(int cost, int speed, int year)
        {
            Cost = cost;
            Speed = speed;
            Year = year;
        }

        public virtual int CalculateCost()
        {
            Cost = Year / 10 + Speed * 10;
            return cost;
        }

        public virtual string GetInfo()
        {
            StringBuilder newStr = new StringBuilder();

            newStr.Append("\n==== Vehicle ==== \n");
            newStr.Append($"Cost: {Cost}\n");
            newStr.Append($"Speed: {Speed}\n");
            newStr.Append($"Year: {Year}");

            return newStr.ToString();
        }

        public int CompareTo(object? other)
        {
            if (other is Vehicle otherVehicle)
            {
                if (this.Cost == otherVehicle.Cost)
                    return this.Speed.CompareTo(otherVehicle.Speed);
                else
                    return this.Cost.CompareTo(otherVehicle.Cost);
            }
            else throw new InvalidCastException();
        }

        object ICloneable.Clone()
        {
            return this.MemberwiseClone();
        }

    }
}
