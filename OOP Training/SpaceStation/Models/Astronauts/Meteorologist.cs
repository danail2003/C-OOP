namespace SpaceStation.Models.Astronauts
{
    using SpaceStation.Models.Astronauts.Contracts;

    public class Meteorologist : Astronaut, IAstronaut
    {
        private const double InitialOxygen = 90;

        public Meteorologist(string name)
            :base(name, InitialOxygen)
        {

        }
    }
}
