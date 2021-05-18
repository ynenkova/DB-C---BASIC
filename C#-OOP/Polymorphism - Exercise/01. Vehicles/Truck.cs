using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Truck : IVehicle
    {
        private double fuelquan;

        private double fuelcon;
        private double tank;
        public Truck(double fuelQuantity, double tank,double fuelConsumption )
        {
            this.FuelQuantity = fuelQuantity;
            this.TankCapacity = tank;
            this.FuelConsumption = fuelConsumption;

        }

        public double FuelQuantity { get; private set; }

        public double FuelConsumption
        {
            get
            {
                return this.fuelcon;
            }
            set
            {
                if (value >= this.TankCapacity)
                {
                    this.fuelcon = 0;
                }
                else
                {
                    this.fuelcon = value;
                }

            }
        }

        public double TankCapacity { get; private set; }

        public string Drive(double drivedistance)
        {
            var calculation = drivedistance * (this.FuelConsumption + 1.6);
            if (calculation > this.FuelQuantity)
            {
                throw new ArgumentException("Truck needs refueling");
            }

            this.FuelQuantity -= calculation;
            return $"Truck travelled {drivedistance} km";
        }

        public void Refuel(double refuelLitter)
        {

            if (refuelLitter <= 0)
            {
                Console.WriteLine("Fuel must be a positive number");
            }
            else
            {
                var total = refuelLitter * 0.95;
                if (this.FuelConsumption + total > TankCapacity)
                {
                    throw new ArgumentException($"Cannot fit {refuelLitter} fuel in the tank");
                }
                this.FuelQuantity += total;
            }

        }
    }
}
