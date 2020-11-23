using System;

namespace HotelReservation
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string[] info = Console.ReadLine().Split();
            string discount = "None";

            if (info.Length > 3)
            {
                discount = info[3];
            }

            var result = PriceCalculator.CalculatePrice(decimal.Parse(info[0]), int.Parse(info[1]), Enum.Parse<Season>(info[2]), Enum.Parse<Discount>(discount));
            Console.WriteLine($"{result:f2}");
        }
    }
}
