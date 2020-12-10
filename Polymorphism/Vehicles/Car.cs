using System;

namespace Vehicles
{
    public class Car : Vehicle
    {
        private const double airConditioner = 0.9;

        public Car(double fuelQuantity, double fuelConsumption, int tankCapacity)
            :base(fuelQuantity,fuelConsumption,tankCapacity)
        {
            
        }

        public override string Drive(double km)
        {
            double result = this.FuelQuantity - (km * (this.FuelConsumptionInLiters + airConditioner));

            if(result < 0)
            {
                throw new ArgumentException("Car needs refueling");
            }

            this.FuelQuantity -= km * (this.FuelConsumptionInLiters + airConditioner);

            return $"Car travelled {km} km";
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
    }
}
