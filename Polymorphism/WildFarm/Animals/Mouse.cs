using System;

namespace WildFarm.Animals
{
    using WildFarm.Food;

    public class Mouse : Mammal
    {
        public Mouse(string name, double weight, string livingRegion)
            :base(name, weight, livingRegion)
        {

        }

        public override double WeightPerFood => 0.10;

        public override string ProduceSound()
        {
            return "Squeak";
        }

        public override void ValidateFood(Food food)
        {
            if(food.GetType().Name != nameof(Vegetable) && food.GetType().Name != nameof(Fruit))
            {
                throw new ArgumentException($"{this.GetType().Name} does not eat {food.GetType().Name}!");
            }
        }

        public override string ToString()
        {
            return base.ToString() + $"{this.Weight + this.FoodEaten * this.WeightPerFood}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}
