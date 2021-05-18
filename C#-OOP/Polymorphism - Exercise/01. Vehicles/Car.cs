using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Car : IVehicle
    {
        private double fuelquantity;
        private double fuelconsumption;
        private double tanks;

        public Car(double fuelquantity,double tank, double fuelconsumption )
        {
            this.FuelQuantity = fuelquantity;
            this.TankCapacity = tank;
            this.FuelConsumption = fuelconsumption;

        }

        public double FuelQuantity { get; private set; }

        public double FuelConsumption
        {
            get
            {
                return this.fuelconsumption;
            }
            set
            {
                if (value >= this.TankCapacity)
                {
                    this.fuelconsumption = 0;
                }
                else
                {
                    this.fuelconsumption = value;
                }

            }
        }

        public double TankCapacity { get; private set; }

        public string Drive(double drivedistance)
        {
            var calculation = drivedistance * (this.FuelConsumption + 0.9);

            if (calculation > this.FuelQuantity)
            {
                throw new ArgumentException("Car needs refueling");
            }

            this.FuelQuantity -= calculation;
            return $"Car travelled {drivedistance} km";
        }

        public void Refuel(double refuelLitter)
        {
            if (this.FuelConsumption + refuelLitter > TankCapacity)
            {
                throw new ArgumentException($"Cannot fit {refuelLitter} fuel in the tank");
            }
            if (refuelLitter <= 0)
            {
                Console.WriteLine("Fuel must be a positive number");
            }
            else
            {
                this.FuelQuantity += refuelLitter;
            }
        }
    }
}
