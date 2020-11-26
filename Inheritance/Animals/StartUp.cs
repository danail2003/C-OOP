namespace Animals
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main()
        {
            string animal = Console.ReadLine();

            List<Animal> animals = new List<Animal>();

            while (animal != "Beast!")
            {
                string[] token = Console.ReadLine().Split();

                try
                {
                    if (animal == "Cat")
                    {
                        animals.Add(new Cat(token[0], int.Parse(token[1]), token[2]));
                    }
                    else if (animal == "Dog")
                    {
                        animals.Add(new Dog(token[0], int.Parse(token[1]), token[2]));
                    }
                    else if (animal == "Frog")
                    {
                        animals.Add(new Frog(token[0], int.Parse(token[1]), token[2]));
                    }
                    else if (animal == "Kitten")
                    {
                        animals.Add(new Kitten(token[0], int.Parse(token[1])));
                    }
                    else if (animal == "Tomcat")
                    {
                        animals.Add(new Tomcat(token[0], int.Parse(token[1])));
                    }
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }

                animal = Console.ReadLine();
            }

            foreach (var currentAnimal in animals)
            {
                Console.WriteLine(currentAnimal);
            }
        }
    }
}
