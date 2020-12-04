namespace Ferrari
{
    public class Ferrari : IDriveable
    {
        public Ferrari(string name)
        {
            this.Name = name;
            this.Model = "488-Spider";
        }

        public string Name { get; set; }
        public string Model { get;}

        public string Brake()
        {
            return "Brakes!";
        }

        public string Gas()
        {
            return "Zadu6avam sA!";
        }
    }
}
