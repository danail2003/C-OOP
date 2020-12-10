using System;

namespace Vehicles
{
    public class StartUp
    {
        public static void Main()
        {
            string[] carInfo = Console.ReadLine().Split();
            string[] truckInfo = Console.ReadLine().Split();
            string[] busInfo = Console.ReadLine().Split();

            Vehicle car = new Car(double.Parse(carInfo[1]), double.Parse(carInfo[2]), int.Parse(carInfo[3]));
            Vehicle truck = new Truck(double.Parse(truckInfo[1]), double.Parse(truckInfo[2]), int.Parse(truckInfo[3]));
            Vehicle bus = new Bus(double.Parse(busInfo[1]), double.Parse(busInfo[2]), int.Parse(busInfo[3]));

            int commands = int.Parse(Console.ReadLine());

            for (int i = 0; i < commands; i++)
            {
                string[] token = Console.ReadLine().Split();

                try
                {
                    if (token[0] == "Drive")
                    {
                        if (token[1] == "Car")
                        {
                            Console.WriteLine(car.Drive(double.Parse(token[2])));
                        }
                        else if (token[1] == "Truck")
                        {
                            Console.WriteLine(truck.Drive(double.Parse(token[2])));
                        }
                        else if (token[1] == "Bus")
                        {
                            Console.WriteLine(bus.Drive(double.Parse(token[2])));
                        }
                    }
                    else if (token[0] == "Refuel")
                    {
                        if (token[1] == "Car")
                        {
                            car.Refuel(double.Parse(token[2]));
                        }
                        else if (token[1] == "Truck")
                        {
                            truck.Refuel(double.Parse(token[2]));
                        }
                        else if (token[1] == "Bus")
                        {
                            bus.Refuel(double.Parse(token[2]));
                        }
                    }
                    else if (token[0] == "DriveEmpty")
                    {
                        Bus emptyBus = bus as Bus;

                        Console.WriteLine(emptyBus.DriveEmpty(double.Parse(token[2])));
                    }
                }
                catch(ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            Console.WriteLine($"Car: {car.FuelQuantity:f2}");
            Console.WriteLine($"Truck: {truck.FuelQuantity:f2}");
            Console.WriteLine($"Bus: {bus.FuelQuantity:f2}");
        }
    }
}
