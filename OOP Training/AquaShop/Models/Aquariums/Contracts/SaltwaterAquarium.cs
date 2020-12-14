namespace AquaShop.Models.Aquariums.Contracts
{
    public class SaltwaterAquarium : Aquarium, IAquarium
    {
        private const int InitialCapacity = 25;

        public SaltwaterAquarium(string name)
            :base(name, InitialCapacity)
        {

        }
    }
}
