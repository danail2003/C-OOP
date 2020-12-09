﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace PizzaCalories
{
    public class Pizza
    {
        private string name;
        private readonly List<Topping> toppings;

        public Pizza(string name, Dough dough)
        {
            this.Name = name;
            this.Dough = dough;
            this.toppings = new List<Topping>();
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if(string.IsNullOrEmpty(value) || value.Length > 15)
                {
                    throw new Exception("Pizza name should be between 1 and 15 symbols.");
                }

                this.name = value;
            }
        }

        public Dough Dough { get; set; }

        public void AddTopping(Topping topping)
        {
            if (this.toppings.Count == 10)
            {
                throw new Exception("Number of toppings should be in range [0..10].");
            }

            this.toppings.Add(topping);
        }

        public override string ToString()
        {
            double calories = this.Dough.CalculatingCalories() + this.toppings.Sum(x => x.CalculatingToppingCalories());

            return $"{this.Name} - {calories:f2} Calories.".ToString();
        }
    }
}
