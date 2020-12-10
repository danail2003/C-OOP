using System;

namespace Vehicles
{
    public class Truck : Vehicle
    {
        private const double airConditioner = 1.6;

        public Truck(double fuelQuantity, double fuelConsumption, int tankCapacity)
            :base(fuelQuantity,fuelConsumption,tankCapacity)
        {
            
        }

        public override string Drive(double km)
        {
            double result = FuelQuantity - (km * (this.FuelConsumptionInLiters + airConditioner));

            if (result < 0)
            {
                throw new ArgumentException("Truck needs refueling");
            }

            this.FuelQuantity -= km * (this.FuelConsumptionInLiters + airConditioner);

            return $"Truck travelled {km} km";
        }

        public override void Refuel(double liters)
        {
            if (liters <= 0)
            {
                throw new ArgumentException("Fuel must be a positive number");
            }
            else if (this.FuelQuantity + liters > TankCapacity)
            {
                throw new ArgumentException($"Cannot fit {liters} fuel in the tank");
            }

            liters *= 0.95;
            this.FuelQuantity += liters;
        }
    }
}
