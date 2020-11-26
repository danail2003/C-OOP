namespace NeedForSpeed
{
    using System;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            Vehicle vehicle = new Vehicle(300, 100);
            Vehicle car = new Car(100, 100);
            Vehicle raceMotorcycle = new RaceMotorcycle(100, 100);
            Vehicle raceCar = new SportCar(100, 100);

            vehicle.Drive(10);
            car.Drive(10);
            raceMotorcycle.Drive(10);
            raceCar.Drive(10);

            Console.WriteLine(vehicle.Fuel);
            Console.WriteLine(car.Fuel);
            Console.WriteLine(raceMotorcycle.Fuel);
            Console.WriteLine(raceCar.Fuel);
        }
    }
}
