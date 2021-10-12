using System;

namespace Cars.Models
{
    class Truck : Car
    {
        public static readonly int maxCarrying = 3000; //кг
        private int _truckLoad;

        //загруженность грузовика
        public int TruckLoad
        {
            get { return _truckLoad; }
            set
            {
                if (value > maxCarrying || (_truckLoad + value) > maxCarrying)
                    throw new Exception("Превышена допустимая вместительность грузовика!");
                if (value < 0)
                    throw new Exception("Значение не может быть отрицательным");
                _truckLoad = value;
                _rangeDistProcent -= ((_truckLoad/200) * 4);
            }
        }
        public Truck()
        {
            FuelTankVol = 350;
            CarType = CarType.Truck;
            FuelConsumptionAvg = 17;
            Speed = 150;

        }
    }
}
