using System;
using System.Collections.Generic;
using System.Linq;

namespace Speed_Racing
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();
            var n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                var vecicle = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
                var model = vecicle[0];
                var fuelAmount = double.Parse(vecicle[1]);
                var fuelPerKm = double.Parse(vecicle[2]);
                Car newCar = new Car(model, fuelAmount, fuelPerKm);
                cars.Add(newCar);
            }

            while (true)
            {
                var moveDistance = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
                if (moveDistance[0]=="End")
                {
                    break;
                }
                var model = moveDistance[1];
                var amountOfKm = double.Parse(moveDistance[2]);
                cars.Where(m => m.Model == model).ToList().ForEach(x => x.Drive(amountOfKm));
            }
            foreach  (Car item in cars)
            {
                Console.WriteLine($"{item.Model} {item.FuelAmount:f2} {item.TravelledDistance}");
            }
        }
    }
}
