using System;
using Cars.Models;

namespace Cars
{
    class Program
    {
        static void Main(string[] args)
        {
            Truck truck = new Truck();
            truck.TruckLoad = 500;
            truck.TruckLoad = 500;
            Console.WriteLine( truck.TruckLoad);
            Console.WriteLine(truck.Speed);
                        Console.WriteLine(truck.GetRangeDictance());
        }
    }
}
