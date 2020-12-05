using System;

namespace Telephony
{
    public class StartUp
    {
        public static void Main()
        {
            string[] numbers = Console.ReadLine().Split();
            string[] sites = Console.ReadLine().Split();
            Smartphone smartphone = new Smartphone();

            foreach (var number in numbers)
            {
                Console.WriteLine(smartphone.Calling(number));
            }

            foreach (var site in sites)
            {
                Console.WriteLine(smartphone.Browsing(site));
            }
        }
    }
}
