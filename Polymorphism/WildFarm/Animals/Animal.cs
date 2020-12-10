namespace WildFarm.Animals
{
    using WildFarm.Food;

    public abstract class Animal
    {
        public Animal(string name, double weight)
        {
            this.Name = name;
            this.Weight = weight;
        }

        public string Name { get; set; }

        public double Weight { get; private set; }

        public int FoodEaten { get; set; }

        public abstract double WeightPerFood { get; }

        public abstract string ProduceSound();

        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, ";
        }

        public virtual void EatFood(Food food)
        {
            ValidateFood(food);

            this.FoodEaten += food.Quantity;
        }

        public abstract void ValidateFood(Food food);
    }
}
