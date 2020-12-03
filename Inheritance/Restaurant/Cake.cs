namespace Restaurant
{
    public class Cake : Dessert
    {
        private const double grams = 250;
        private const decimal price = 5;
        public const double calories = 1000;

        public Cake(string name)
            :base(name, 0, 0, 0)
        {
            this.Name = name;
        }

        public override double Grams => grams;
        public override decimal Price => price;
        public override double Calories => calories;
    }
}
