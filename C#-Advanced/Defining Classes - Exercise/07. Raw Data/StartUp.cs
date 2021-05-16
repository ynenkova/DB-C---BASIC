using System;
using System.Linq;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace RawData
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();
            for (int i = 0; i < n; i++)
            {
                var carInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();

                var model = carInfo[0];
                var speed = int.Parse(carInfo[1]);
                var power = int.Parse(carInfo[2]);
                var weight = int.Parse(carInfo[3]);
                var type = carInfo[4];
                var tire1Pressure = double.Parse(carInfo[5]);
                var tire1Age = int.Parse(carInfo[6]);
                var tire2Pressure = double.Parse(carInfo[7]);
                var tire2Age = int.Parse(carInfo[8]);
                var tire3Pressure = double.Parse(carInfo[9]);
                var tire3Age = int.Parse(carInfo[10]);
                var tire4Pressure = double.Parse(carInfo[11]);
                var tire4Age = int.Parse(carInfo[12]);
                Car newcars = new Car(model, new Engine(speed, power), new Cargo(type, weight), new List<Tire> { new Tire(tire1Pressure, tire1Age), new Tire(tire2Pressure, tire2Age), new Tire(tire2Pressure, tire3Age), new Tire(tire4Pressure, tire4Age) });
                cars.Add(newcars);
            }
            var command = Console.ReadLine();
            if (command == "fragile")
            {
                cars.Where(x => x.cargo.CargoType == command).Where(x => x.tire.Any(x => x.TirePress < 1)).ToList().ForEach(x => Console.WriteLine(x.Model));
            }
            else if (command == "flamable")
            {
                cars.Where(x => x.cargo.CargoType == command).Where(x => x.engine.EnginePower>250).ToList().ForEach(x => Console.WriteLine(x.Model));
            }
        }
    }
}
