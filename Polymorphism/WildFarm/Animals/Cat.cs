using System;

namespace WildFarm.Animals
{
    using WildFarm.Food;

    public class Cat : Feline
    {
        public Cat(string name, double weight, string livingRegion, string breed)
            :base(name, weight, livingRegion, breed)
        {

        }

        public override double WeightPerFood => 0.3;

        public override string ProduceSound()
        {
            return "Meow";
        }

        public override void ValidateFood(Food food)
        {
            if(food.GetType().Name != nameof(Vegetable) && food.GetType().Name != nameof(Meat))
            {
                throw new ArgumentException($"{this.GetType().Name} does not eat {food.GetType().Name}!");
            }
        }
    }
}
