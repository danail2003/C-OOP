namespace SpaceStation.Models.Astronauts
{
    using SpaceStation.Models.Astronauts.Contracts;

    public class Geodesist : Astronaut, IAstronaut
    {
        private const double InitialOxygen = 50;

        public Geodesist(string name)
            :base(name, InitialOxygen)
        {

        }
    }
}
