using System;
using System.Collections.Generic;

namespace WildFarm.Food
{
    using WildFarm.Animals;
    using WildFarm.Creater;

    public class StartUp
    {
        public static void Main()
        {
            List<Animal> animals = new List<Animal>();
            string command = Console.ReadLine();

            while (command != "End")
            {
                string[] token = command.Split();

                Animal animal = AnimalsCreater.CreateAnimal(token);
                animals.Add(animal);
                Console.WriteLine(animal.ProduceSound());

                string[] foodInfo = Console.ReadLine().Split();
                Food food = FoodCreater.CreateFood(foodInfo);

                try
                {
                    animal.EatFood(food);
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }

                command = Console.ReadLine();
            }

            foreach (var animal in animals)
            {
                Console.WriteLine(animal);
            }
        }
    }
}
