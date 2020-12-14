namespace AquaShop.Models.Decorations.Contracts
{
    public class Ornament : Decoration, IDecoration
    {
        private const int InitialComfort = 1;
        private const decimal InitialPrice = 5;

        public Ornament()
            :base(InitialComfort, InitialPrice)
        {

        }
    }
}
