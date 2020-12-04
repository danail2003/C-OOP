using System;
using System.Collections.Generic;
using System.Linq;

namespace BorderControl
{
    public class StartUp
    {
        public static void Main()
        {
            List<IBuyer> citizensAndRebels = new List<IBuyer>();

            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                string[] token = Console.ReadLine().Split();

                if (token.Length == 4)
                {
                    IBuyer citizen = new Citizen(token[0], int.Parse(token[1]), token[2], token[3]);
                    citizensAndRebels.Add(citizen);
                }
                else if (token.Length == 3)
                {
                    IBuyer rebel = new Rebel(token[0], int.Parse(token[1]), token[2]);
                    citizensAndRebels.Add(rebel);
                }
            }

            while (true)
            {
                string name = Console.ReadLine();

                if (name == "End")
                {
                    break;
                }

                IBuyer buyer = citizensAndRebels.FirstOrDefault(x => x.Name == name);

                if (buyer != null)
                {
                    buyer.BuyFood();
                }
            }

            Console.WriteLine(citizensAndRebels.Sum(x => x.Food));
        }
    }
}
