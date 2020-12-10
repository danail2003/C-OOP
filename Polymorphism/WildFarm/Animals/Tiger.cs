using System;

namespace WildFarm.Animals
{
    using WildFarm.Food;

    public class Tiger : Feline
    {
        public Tiger(string name, double weight, string livingRegion, string breed)
            :base(name, weight, livingRegion, breed)
        {

        }

        public override double WeightPerFood => 1;

        public override string ProduceSound()
        {
            return "ROAR!!!";
        }

        public override void ValidateFood(Food food)
        {
            if(food.GetType().Name != nameof(Meat))
            {
                throw new ArgumentException($"{this.GetType().Name} does not eat {food.GetType().Name}!");
            }
        }
    }
}
