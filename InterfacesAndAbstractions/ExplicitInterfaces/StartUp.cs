using System;

namespace ExplicitInterfaces
{
    public class StartUp
    {
        public static void Main()
        {
            while (true)
            {
                string[] token = Console.ReadLine().Split();

                if (token[0] == "End")
                {
                    break;
                }

                IPerson person = new Citizen(token[0], token[1], token[2]);
                Console.WriteLine(person.GetName());

                IResident resident = new Citizen(token[0], token[1], token[2]);
                Console.WriteLine(resident.GetName());
            }
        }
    }
}
