using System;

namespace WildFarm.Animals
{
    using WildFarm.Food;

    public class Owl : Bird
    {
        public Owl(string name, double weight, double wingSize)
            :base(name, weight, wingSize)
        {

        }

        public override double WeightPerFood => 0.25;

        public override string ProduceSound()
        {
            return "Hoot Hoot";
        }

        public override void ValidateFood(Food food)
        {
            if(food.GetType().Name!= nameof(Meat))
            {
                throw new ArgumentException($"{this.GetType().Name} does not eat {food.GetType().Name}!");
            }
        }
    }
}
