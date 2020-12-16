namespace SantaWorkshop.Models.Dwarfs
{
    using SantaWorkshop.Models.Dwarfs.Contracts;

    public class HappyDwarf : Dwarf, IDwarf
    {
        private const int InitialEnergy = 100;

        public HappyDwarf(string name)
            :base(name, InitialEnergy)
        {

        }

        public override void Work()
        {
            if (this.Energy - 10 < 0)
            {
                this.Energy = 0;
            }
            else
            {
                this.Energy -= 10;
            }
        }
    }
}
