namespace Vehicles
{
    public abstract class Vehicle
    {
        public Vehicle(double fuelQuantity, double fuelConsumption, int tankCapacity)
        {
            this.TankCapacity = tankCapacity;
            if (fuelQuantity > this.TankCapacity)
            {
                this.FuelQuantity = 0;
            }
            else
            {
                this.FuelQuantity = fuelQuantity;
            }
            this.FuelConsumptionInLiters = fuelConsumption;
        }

        public double FuelQuantity { get; set; }

        public double FuelConsumptionInLiters { get; set; }

        public int TankCapacity { get; set; }

        public abstract string Drive(double km);

        public abstract void Refuel(double liters);
    }
}
