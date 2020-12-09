using System;

namespace PizzaCalories
{
    public class Dough
    {
        private string flourType;
        private string bakingTechnique;
        private double grams;
        private const double caloriesPerGram = 2;

        public Dough(string flourType, string bakingTechnique, double grams)
        {
            this.FlourType = flourType;
            this.BakingTechnique = bakingTechnique;
            this.Grams = grams;
        }

        public string FlourType
        {
            get => this.flourType;
            private set
            {
                if(value.ToLower() != "white" && value.ToLower() != "wholegrain")
                {
                    throw new Exception("Invalid type of dough.");
                }

                this.flourType = value;
            }
        }
        public string BakingTechnique
        {
            get => this.bakingTechnique;
            private set
            {
                if(value.ToLower() != "crispy" && value.ToLower() != "chewy" && value.ToLower() != "homemade")
                {
                    throw new Exception("Invalid type of dough.");
                }

                this.bakingTechnique = value;
            }
        }
        public double Grams
        {
            get => this.grams;
            private set
            {
                if(value < 1 || value > 200)
                {
                    throw new Exception("Dough weight should be in the range [1..200].");
                }

                this.grams = value;
            }
        }

        public double CalculatingCalories()
        {
            double calories = caloriesPerGram;

            if (this.FlourType.ToLower() == "white")
            {
                calories *= grams * 1.5;
            }
            else if (this.FlourType.ToLower() == "wholegrain")
            {
                calories *= grams * 1;
            }

            if (this.BakingTechnique.ToLower() == "crispy")
            {
                calories *= 0.9;
            }
            else if (this.BakingTechnique.ToLower() == "chewy")
            {
                calories *= 1.1;
            }
            else if (this.BakingTechnique.ToLower() == "homemade")
            {
                calories *= 1;
            }

            return calories;
        }
    }
}
