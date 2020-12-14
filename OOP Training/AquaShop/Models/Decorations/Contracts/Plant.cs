namespace AquaShop.Models.Decorations.Contracts
{
    public class Plant : Decoration, IDecoration
    {
        private const int InitialComfort = 5;
        private const decimal InitialPrice = 10;

        public Plant()
            :base(InitialComfort, InitialPrice)
        {

        }
    }
}
