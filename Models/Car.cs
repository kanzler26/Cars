using System;

namespace Cars.Models
{
    class Car
    {
        private CarType _carType;
        public CarType CarType
        {
            get => _carType;
            protected set => _carType = value;
        }
        private int _speed;
        //km/h
        public int Speed
        {
            get => _speed;
            protected set => _speed = value;
        }
        //запас хода в процентах
        protected int _rangeDistProcent = 100;
        public int RangeDistProcent { get => _rangeDistProcent; }
        protected double _fuelConsumptionAvg = 10;//расход литров на 100 км
        public double FuelConsumptionAvg
        {
            get => _fuelConsumptionAvg;
            protected set => _fuelConsumptionAvg = value;
        }
        /// <summary>
        /// получить средний расход топлива на 100 км
        /// </summary>
        public double CalculateFuelConsumptionAvg(int spfuel, int drovekm)
        {
            if (spfuel > _fuelTankVol)
                throw new Exception("Переданный параметр не может превышать объем бака!");
            double fcAvg = (spfuel / drovekm) * 100;
            _fuelConsumptionAvg = fcAvg;
            return fcAvg;
        }
        //объем топливного бака
        protected int _fuelTankVol = 50;//литров
        public int FuelTankVol
        {
            get => _fuelTankVol;
            protected set => _fuelTankVol = value;
        }
        //остаток топлива
        public readonly int fuelAmount = 25;
        protected double GetRoadLengthOnFullFuelTank() => (_fuelTankVol / _fuelConsumptionAvg) * 100;
        /// <summary>
        /// получить расстояние в км, которое проедет машина в зависимости от остатка запаса хода
        /// </summary>
        public double GetRangeDictance()
        {
            double distanceOnFullFuelTank = Math.Round((_fuelTankVol / _fuelConsumptionAvg) * 100, 2);
            //вычитаем из общего кол-ва км, которое машина может пройти с полным баком, запас хода в километрах
            return Math.Round(((distanceOnFullFuelTank / 100) * _rangeDistProcent), 2);
        }
        //узнать сколько км машина проедет на остатке бензина в баке
        protected double GetRoadLengthOnRemainingFuel() => (fuelAmount / _fuelConsumptionAvg) * 100;
        /// <summary>
        /// Получит время с которым машина преодолеет расстояние
        /// скорость и тип машины определяется по кол-ву переданного топлива
        /// </summary>
        /// <param name="fuel">кол-во топлива</param>
        /// <param name="range">расстояние, которое нужно проехать</param>
        /// <returns></returns>
        public void GetDrivingTime(float fuel, float range)
        {
            if (fuel <= 60)
                CarType = CarType.Passenger;
            else if (fuel >= 60 || fuel <= 85)
                CarType = CarType.Sport;
            else
                CarType = CarType.Truck;
            //получить время за которое будет преодолено расстояние
            var ct = CreateCar();
            var timeTravel = Math.Round((range / ct._speed), 1);//делим дистанцию на скорость авто
            var ts = ConvertNumbToTime(timeTravel);
            Console.WriteLine("Время в пути:{0}h:{1}min", ts.Hours, ts.Minutes);
        }
        private TimeSpan ConvertNumbToTime(double timeTravel)
        {
            var dif = Math.Round(timeTravel - Math.Truncate(timeTravel), 1);//0.8
            var difHours = Math.Round(1 - dif, 2);
            var minutes = 60 - (((60 / 100d) * difHours) * 100);//получить кол-во минут от часа
            return new TimeSpan((int)Math.Truncate(timeTravel), (int)minutes, 0);
        }

        /// <summary>
        ///получить информацию о состоянии запаса хода
        /// </summary>
        public void getRangeDistance()
        {
            var maxRangeDist = GetRoadLengthOnFullFuelTank();
            var difDist = maxRangeDist - ((maxRangeDist / 100) * (100 - this._rangeDistProcent));
            Console.WriteLine("Вы сможете проехать:{0}km", Math.Round(difDist, 1));
        }
        private Car CreateCar()
        {
            switch (_carType)
            {
                case CarType.Passenger:
                    return new PassengerCar();
                case CarType.Sport:
                    return new Sport();
                case CarType.Truck:
                    return new Truck();
                default: return new Car();
            }
        }
    }
}
