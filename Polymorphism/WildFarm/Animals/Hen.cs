using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Animals
{
    using WildFarm.Food;

    public class Hen : Bird
    {
        public Hen(string name, double weight, double wingSize)
            :base(name, weight, wingSize)
        {

        }

        public override double WeightPerFood => 0.35;

        public override string ProduceSound()
        {
            return "Cluck";
        }

        public override void ValidateFood(Food food)
        {
            
        }
    }
}
