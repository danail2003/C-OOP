namespace Animals
{
    public class Animal
    {
        private string name;

        private string favouriteFood;

        public Animal(string name, string favouriteFood)
        {
            this.Name = name;
            this.FavouriteFood = favouriteFood;
        }

        public string Name
        {
            get => this.name;
            private set { this.name = value; }
        }

        public string FavouriteFood
        {
            get => this.favouriteFood;
            private set { this.favouriteFood = value; }
        }

        public virtual string ExplainSelf()
        {
            return $"I am {this.name} and my fovourite food is {this.favouriteFood}";
        }
    }
}
