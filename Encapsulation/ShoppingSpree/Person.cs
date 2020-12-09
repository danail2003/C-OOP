using System;
using System.Collections.Generic;

namespace ShoppingSpree
{
    public class Person
    {
        private string name;
        private decimal money;
        private List<Product> bagOfProducts;

        public Person(string name, decimal money)
        {
            this.Name = name;
            this.Money = money;
            this.bagOfProducts = new List<Product>();
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if(string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }

                this.name = value;
            }
        }

        public decimal Money
        {
            get => this.money;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }

                this.money = value;
            }
        }

        public void AddProduct(Product product)
        {
            this.bagOfProducts.Add(product);
        }

        public List<Product> CountOfProducts()
        {
            return this.bagOfProducts;
        }
    }
}
