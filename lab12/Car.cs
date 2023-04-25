using lab12;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab12
{
    class Car : Vehicle, IVehicleCalculations, ICloneable, IComparable
    {
        public Car(int cost, int speed, int year) : base(cost, speed, year) { }

        public int RecalculateCost(int cost, int speed, int year)
        {
            Cost = Convert.ToInt32((cost + speed + year) * 2 + (cost / 0.5) / 1.5);
            return Cost;
        }

        public string MakeName()
        {
            string name = $"V{Year}Car{Speed}{(Cost > 8000 ? "Premium" : "Stock")}";
            return name;
        }

        public override string GetInfo()
        {
            StringBuilder newStr = new StringBuilder();
            newStr.Append("\n==== Car ==== \n");
            newStr.Append($"Cost: {Cost}\n");
            newStr.Append($"Speed: {Speed}\n");
            newStr.Append($"Year: {Year}");

            return newStr.ToString();
        }

        public new int CompareTo(object? other)
        {
            if (other is Car otherVehicle)
            {
                if (this.Cost == otherVehicle.Cost)
                    return this.Speed.CompareTo(otherVehicle.Speed);
                else
                    return this.Cost.CompareTo(otherVehicle.Cost);
            }
            else throw new InvalidCastException();
        }

        public object Clone()
        {
            Car clone = new Car(this.Cost, this.Speed, this.Year);
            return clone;
        }

    }
}
