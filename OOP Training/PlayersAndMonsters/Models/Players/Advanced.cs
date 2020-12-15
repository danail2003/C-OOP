namespace PlayersAndMonsters.Models.Players
{
    using PlayersAndMonsters.Models.Players.Contracts;
    using PlayersAndMonsters.Repositories.Contracts;

    public class Advanced : Player, IPlayer
    {
        private const int InitialHealth = 250;

        public Advanced(ICardRepository cardRepository, string username)
            :base(cardRepository, username, InitialHealth)
        {

        }
    }
}
