namespace SpaceStation.Models.Astronauts
{
    using SpaceStation.Models.Astronauts.Contracts;

    public class Biologist : Astronaut, IAstronaut
    {
        private const double InitialOxygen = 70;

        public Biologist(string name)
            :base(name, InitialOxygen)
        {

        }

        public override void Breath()
        {
            if (this.Oxygen - 5 < 0)
            {
                this.Oxygen = 0;
            }
            else
            {
                this.Oxygen -= 5;
            }
        }
    }
}
