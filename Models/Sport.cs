using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars.Models
{
    class Sport:Car
    {
        public Sport()
        {
            FuelTankVol = 85;
            CarType = CarType.Sport;
            FuelConsumptionAvg = 12;
            Speed = 250;
        }
    }
}
