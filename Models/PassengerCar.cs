using System;

namespace Cars.Models
{
    class PassengerCar : Car
    {
        public static readonly int maxPassengersCount = 5;
        private int _passengersAmount;
        public int PassengersAmount
        {
            get => _passengersAmount;
            set
            {
                if (value > maxPassengersCount || (_passengersAmount + value) > 5)
                    throw new Exception("Количество пассажиров превышает допустимое");
                if (value < 0)
                    throw new Exception("Значение не может быть отрицательным");
                _passengersAmount += value;
                _rangeDistProcent -= (_passengersAmount * 6);
            }
        }
        public PassengerCar()
        {
            FuelTankVol = 60;
            CarType = CarType.Passenger;
            FuelConsumptionAvg = 10;
            Speed = 195;
        }
    }
}
