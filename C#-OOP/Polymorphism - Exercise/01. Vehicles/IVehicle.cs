using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
   public interface IVehicle
    {
        double FuelQuantity { get; }
        double FuelConsumption { get; }

        double TankCapacity { get; }
        string Drive(double drivedistance);
        void Refuel(double refuelLitter);
    }
}
