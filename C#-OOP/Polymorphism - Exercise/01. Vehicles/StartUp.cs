using System;

namespace Vehicles
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var inputCar = Console.ReadLine().Split(" ");
            var car = new Car(double.Parse(inputCar[1]), double.Parse(inputCar[3]), double.Parse(inputCar[2]));

            var inputTruck = Console.ReadLine().Split(" ");
            var truck = new Truck(double.Parse(inputTruck[1]), double.Parse(inputTruck[3]), double.Parse(inputTruck[2]));

            var inputBus = Console.ReadLine().Split(" ");
            var bus = new Bus(double.Parse(inputBus[1]), double.Parse(inputBus[3]), double.Parse(inputBus[2]));

            var n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split(" ");
                if (input[0] == "Drive")
                {
                    try
                    {
                        if (input[1] == "Car")
                        {
                            Console.WriteLine(car.Drive(double.Parse(input[2])));
                        }
                        else if (input[1] == "Truck")
                        {
                            Console.WriteLine(truck.Drive(double.Parse(input[2])));
                        }
                        else
                        {

                            Console.WriteLine(bus.Drive(double.Parse(input[2])));
                        }
                    }
                    catch (Exception e)
                    {

                        Console.WriteLine(e.Message);
                    }
                }
                else if (input[0] == "DriveEmpty")
                {
                    try
                    {
                        bus.IsDriveEmpy = false;
                        Console.WriteLine(bus.Drive(double.Parse(input[2])));
                    }
                    catch (Exception e)
                    {

                        Console.WriteLine(e.Message);
                    }

                }
                else if (input[0] == "Refuel")
                {
                    try
                    {
                        if (input[1] == "Car")
                        {
                            car.Refuel(double.Parse(input[2]));
                        }
                        else if (input[1] == "Truck")
                        {
                            truck.Refuel(double.Parse(input[2]));
                        }
                        else
                        {
                            bus.Refuel(double.Parse(input[2]));
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
            }
            Console.WriteLine($"Car: {car.FuelQuantity:f2}");
            Console.WriteLine($"Truck: {truck.FuelQuantity:f2}");
            Console.WriteLine($"Bus: {bus.FuelQuantity:f2}");
        }
    }
}
