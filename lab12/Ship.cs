using lab12;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab12
{
    class Ship : Vehicle, ICloneable, IComparable
    {
        private int passengerNum;
        public int PassengerNum
        {
            get => passengerNum;
            set => passengerNum = value < 0 ? throw new Exception("Passenger number can't be negative value") : value;
        }

        private string port = "Main port";
        public string Port
        {
            get => port;
            set => port = string.IsNullOrEmpty(value) ? throw new Exception("Port name can't be empty") : value;
        }

        public Ship(int cost, int speed, int year, int passengerNum, string port) : base(cost, speed, year)
        {
            Port = port;
            PassengerNum = passengerNum;
        }

        public override int CalculateCost()
        {
            Cost = Year / 10 + Speed * 10 + passengerNum * 20;
            return Cost;
        }

        public override string GetInfo()
        {
            StringBuilder newStr = new StringBuilder();
            newStr.Append("\n==== Ship ==== \n");
            newStr.Append($"Cost: {Cost}\n");
            newStr.Append($"Speed: {Speed}\n");
            newStr.Append($"Year: {Year}\n");
            newStr.Append($"Passenger number: {PassengerNum}\n");
            newStr.Append($"Port: {Port}");

            return newStr.ToString();
        }

        public new int CompareTo(object? other)
        {
            if (other is Ship otherVehicle)
            {
                if (this.Cost == otherVehicle.Cost)
                    return this.Speed.CompareTo(otherVehicle.Speed);
                else if (this.PassengerNum == otherVehicle.PassengerNum)
                    return this.Cost.CompareTo(otherVehicle.Cost);
                else
                    return this.PassengerNum.CompareTo(otherVehicle.PassengerNum);
            }
            else throw new InvalidCastException();
        }

        public object Clone()
        {
            Ship clone = new Ship(this.Cost, this.Speed, this.Year, this.PassengerNum, this.Port);
            return clone;
        }

    }
}
