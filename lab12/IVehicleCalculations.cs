using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab12
{
    interface IVehicleCalculations
    {
        int RecalculateCost(int cost, int speed, int year);
        string MakeName();
    }
}
