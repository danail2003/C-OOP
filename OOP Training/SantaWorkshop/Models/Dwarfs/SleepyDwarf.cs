namespace SantaWorkshop.Models.Dwarfs
{
    using SantaWorkshop.Models.Dwarfs.Contracts;

    public class SleepyDwarf : Dwarf, IDwarf
    {
        private const int InitialEnergy = 50;

        public SleepyDwarf(string name)
            :base(name, InitialEnergy)
        {

        }

        public override void Work()
        {
            if (this.Energy - 15 < 0)
            {
                this.Energy = 0;
            }
            else
            {
                this.Energy -= 15;
            }
        }
    }
}
