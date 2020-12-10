using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Bus : Vehicle
    {
        private const double airConditioner = 1.4;

        public Bus(double fuelQuantity, double fuelConsumption, int tankCapacity)
            :base(fuelQuantity, fuelConsumption, tankCapacity)
        {

        }

        public override string Drive(double km)
        {
            double result = this.FuelQuantity - (km * (this.FuelConsumptionInLiters + airConditioner));

            if (result < 0)
            {
                throw new ArgumentException("Bus needs refueling");
            }

            this.FuelQuantity -= km * (this.FuelConsumptionInLiters + airConditioner);

            return $"Bus travelled {km} km";
        }

        public override void Refuel(double liters)
        {
            if (liters <= 0)
            {
                throw new ArgumentException("Fuel must be a positive number");
            }
            else if (this.FuelQuantity + liters > this.TankCapacity)
            {
                throw new ArgumentException($"Cannot fit {liters} fuel in the tank");
            }

            this.FuelQuantity += liters;
        }

        public string DriveEmpty(double km)
        {
            double result = this.FuelQuantity - (km * this.FuelConsumptionInLiters);

            if (result < 0)
            {
                throw new ArgumentException("Bus needs refueling");
            }

            this.FuelQuantity -= (km * this.FuelConsumptionInLiters);

            return $"Bus travelled {km} km";
        }
    }
}
