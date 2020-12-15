namespace PlayersAndMonsters.Core
{
    using System.Text;

    using Contracts;
    using PlayersAndMonsters.Repositories.Contracts;
    using PlayersAndMonsters.Repositories;
    using PlayersAndMonsters.Models.Players;
    using PlayersAndMonsters.Common;
    using PlayersAndMonsters.Models.Cards;
    using PlayersAndMonsters.Models.Players.Contracts;
    using PlayersAndMonsters.Models.Cards.Contracts;
    using PlayersAndMonsters.Models.BattleFields;

    public class ManagerController : IManagerController
    {
        private readonly ICardRepository cardRepository;
        private readonly IPlayerRepository playerRepository;

        public ManagerController()
        {
            this.cardRepository = new CardRepository();
            this.playerRepository = new PlayerRepository();
        }

        public string AddPlayer(string type, string username)
        {
            if (type == nameof(Beginner))
            {
                this.playerRepository.Add(new Beginner(new CardRepository(), username));
            }
            else if (type == nameof(Advanced))
            {
                this.playerRepository.Add(new Advanced(new CardRepository(), username));
            }

            return string.Format(ConstantMessages.SuccessfullyAddedPlayer, type, username);
        }

        public string AddCard(string type, string name)
        {
            if (type == "Magic")
            {
                this.cardRepository.Add(new MagicCard(name));
            }
            else if(type == "Trap")
            {
                this.cardRepository.Add(new TrapCard(name));
            }

            return string.Format(ConstantMessages.SuccessfullyAddedCard, type, name);
        }

        public string AddPlayerCard(string username, string cardName)
        {
            IPlayer player = this.playerRepository.Find(username);
            ICard card = this.cardRepository.Find(cardName);

            player.CardRepository.Add(card);

            return string.Format(ConstantMessages.SuccessfullyAddedPlayerWithCards, cardName, username);
        }

        public string Fight(string attackUser, string enemyUser)
        {
            BattleField battleField = new BattleField();

            IPlayer attacker = this.playerRepository.Find(attackUser);
            IPlayer enemy = this.playerRepository.Find(enemyUser);

            battleField.Fight(attacker, enemy);

            return string.Format(ConstantMessages.FightInfo, attacker.Health, enemy.Health);
        }

        public string Report()
        {
            StringBuilder stringBuilder = new StringBuilder();

            foreach (var player in this.playerRepository.Players)
            {
                stringBuilder.AppendLine(string.Format(ConstantMessages.PlayerReportInfo, player.Username, player.Health, player.CardRepository.Cards.Count));

                foreach (var card in player.CardRepository.Cards)
                {
                    stringBuilder.AppendLine(string.Format(ConstantMessages.CardReportInfo, card.Name, card.DamagePoints));
                }

                stringBuilder.AppendLine(string.Format(ConstantMessages.DefaultReportSeparator));
            }

            return stringBuilder.ToString().TrimEnd();
        }
    }
}
