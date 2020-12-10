using System;

namespace WildFarm.Animals
{
    using WildFarm.Food;

    public class Dog : Mammal
    {
        public Dog(string name, double weight, string livingRegion)
            :base(name, weight, livingRegion)
        {

        }

        public override double WeightPerFood => 0.4;

        public override string ProduceSound()
        {
            return "Woof!";
        }

        public override void ValidateFood(Food food)
        {
            if(food.GetType().Name != nameof(Meat))
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
