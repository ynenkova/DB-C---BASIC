using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Vehicles
{
    public class Bus : IVehicle
    {
        private double quantity;
        private double consumation;
        private double tank;
        private bool isempty;

        public Bus(double quantity, double tank, double consumation)
        {
            this.FuelQuantity = quantity;
            this.TankCapacity = tank;
            this.FuelConsumption = consumation;
            this.IsDriveEmpy = true;
        }
        public double FuelQuantity { get; private set; }
        public double FuelConsumption
        {
            get
            {
                return this.consumation;
            }
            set
            {
                if (value >= this.TankCapacity)
                {
                    this.consumation = 0;
                }
                else
                {
                    this.consumation = value;
                }

            }
        }
        public double TankCapacity { get; private set; }
        public bool IsDriveEmpy
        {
            get
            {
                return this.isempty;
            }
            set
            {
                this.isempty = true;
            }
        }
        public string Drive(double drivedistance)
        {
            if (this.IsDriveEmpy != false)
            {
                var calculation = drivedistance * (this.FuelConsumption + 1.4);
                if (calculation > this.FuelQuantity)
                {
                    throw new ArgumentException("Bus needs refueling");
                }

                this.FuelQuantity -= calculation;
            }
            else
            {
                var calculation = drivedistance * this.FuelConsumption;
                this.FuelQuantity -= calculation;
            }

            return $"Bus travelled {drivedistance} km";
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
