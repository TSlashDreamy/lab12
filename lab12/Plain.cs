using lab12;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab12
{
    class Plain : Vehicle, ICloneable, IComparable
    {
        private int height;
        public int Height
        {
            get => height;
            set => height = value < 0 ? throw new Exception("Height value can't be negative value") : value;
        }

        private int passengerNum;
        public int PassengerNum
        {
            get => passengerNum;
            set => passengerNum = value < 0 ? throw new Exception("Passenger number can't be negative value") : value;
        }

        public Plain(int cost, int speed, int year, int height, int passengerNum) : base(cost, speed, year)
        {
            Height = height;
            PassengerNum = passengerNum;
        }

        public override int CalculateCost()
        {
            Cost = Year / 10 + Speed * 10 + Height * 5 + PassengerNum * 20;
            return Cost;
        }

        public override string GetInfo()
        {
            StringBuilder newStr = new StringBuilder();
            newStr.Append("\n==== Plain ==== \n");
            newStr.Append($"Cost: {Cost}\n");
            newStr.Append($"Speed: {Speed}\n");
            newStr.Append($"Year: {Year}\n");
            newStr.Append($"Height: {Height}\n");
            newStr.Append($"Passenger number: {PassengerNum}\n");

            return newStr.ToString();
        }

        public new int CompareTo(object? other)
        {
            if (other is Plain otherVehicle)
            {
                if (this.Cost == otherVehicle.Cost)
                    return this.Speed.CompareTo(otherVehicle.Speed);
                else if (this.Height == otherVehicle.Height)
                    return this.Cost.CompareTo(otherVehicle.Cost);
                else
                    return this.Height.CompareTo(otherVehicle.Height);
            }
            else throw new InvalidCastException();
        }

        public object Clone()
        {
            Plain clone = new Plain(this.Cost, this.Speed, this.Year, this.Height, this.PassengerNum);
            return clone;
        }

    }


}


