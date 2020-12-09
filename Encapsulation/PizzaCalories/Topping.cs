using System;

namespace PizzaCalories
{
    public class Topping
    {
        private string type;
        private double weight;
        private const double grams = 2;

        public Topping(string type, double weight)
        {
            this.Type = type;
            this.Weight = weight;
        }

        public string Type
        {
            get => this.type;
            private set
            {
                if(value.ToLower() != "meat" && value.ToLower() != "veggies" && value.ToLower() != "cheese" && value.ToLower() != "sauce")
                {
                    throw new Exception($"Cannot place {value} on top of your pizza.");
                }

                this.type = value;
            }
        }

        public double Weight
        {
            get => this.weight;
            private set
            {
                if(value < 1 || value > 50)
                {
                    throw new Exception($"{this.Type} weight should be in the range [1..50].");
                }

                this.weight = value;
            }
        }

        public double CalculatingToppingCalories()
        {
            double calories = grams;

            if(this.Type.ToLower() == "meat")
            {
                calories *= weight * 1.2;
            }
            else if (this.Type.ToLower() == "veggies")
            {
                calories *= weight * 0.8;
            }
            else if (this.Type.ToLower() == "cheese")
            {
                calories *= weight * 1.1;
            }
            else if (this.Type.ToLower() == "sauce")
            {
                calories *= weight * 0.9;
            }

            return calories;
        }
    }
}
