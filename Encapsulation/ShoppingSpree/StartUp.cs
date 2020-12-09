using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingSpree
{
    public class StartUp
    {
        public static void Main()
        {
            string[] people = Console.ReadLine().Split(new char[] { '=', ';'});
            string[] products = Console.ReadLine().Split(new char[] { '=', ';'});
            string command = Console.ReadLine();
            List<Person> listOfPeople = new List<Person>();
            List<Product> listOfProducts = new List<Product>();

            for (int i = 0; i < people.Length; i += 2)
            {
                try
                {
                    listOfPeople.Add(new Person(people[i], decimal.Parse(people[i + 1])));
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                    return;
                }
            }

            for (int i = 0; i < products.Length; i += 2)
            {
                try
                {
                    listOfProducts.Add(new Product(products[i], decimal.Parse(products[i + 1])));
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                    return;
                }
            }

            while (command != "END")
            {
                string[] token = command.Split();

                Person person = listOfPeople.FirstOrDefault(x => x.Name == token[0]);
                Product product = listOfProducts.FirstOrDefault(x => x.Name == token[1]);

                if (person.Money >= product.Cost)
                {
                    person.Money -= product.Cost;
                    person.AddProduct(product);
                    Console.WriteLine($"{person.Name} bought {product.Name}");
                }
                else
                {
                    Console.WriteLine($"{person.Name} can't afford {product.Name}");
                }

                command = Console.ReadLine();
            }

            foreach (var person in listOfPeople)
            {
                if (person.CountOfProducts().Count > 0)
                {
                    Console.WriteLine($"{person.Name} - {string.Join(", ", person.CountOfProducts().Select(x => x.Name))}");
                }
                else
                {
                    Console.WriteLine($"{person.Name} - Nothing bought");
                }
            }
        }
    }
}
