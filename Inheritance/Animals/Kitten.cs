namespace Animals
{
    class Kitten : Cat
    {
        public Kitten(string name, int age)
            :base(name, age, "Female")
        {

        }

        public override string ProduceSound()
        {
            return "Meow".ToString().TrimEnd();
        }
    }
}
