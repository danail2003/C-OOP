namespace PlayersAndMonsters.Models.Cards
{
    using PlayersAndMonsters.Models.Cards.Contracts;

    public class TrapCard : Card, ICard
    {
        private const int InitialDamagePoints = 120;
        private const int InitialHealthPoints = 5;

        public TrapCard(string name)
            :base(name, InitialDamagePoints, InitialHealthPoints)
        {

        }
    }
}
