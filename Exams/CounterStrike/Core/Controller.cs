namespace CounterStrike.Core
{
    using System;
    using System.Linq;
    using System.Text;
    using System.Collections.Generic;
    using CounterStrike.Core.Contracts;
    using CounterStrike.Models.Guns;
    using CounterStrike.Models.Guns.Contracts;
    using CounterStrike.Models.Maps;
    using CounterStrike.Models.Maps.Contracts;
    using CounterStrike.Models.Players;
    using CounterStrike.Models.Players.Contracts;
    using CounterStrike.Repositories;
    using CounterStrike.Utilities.Messages;

    public class Controller : IController
    {
        private readonly GunRepository gunRepository;
        private readonly PlayerRepository playerRepository;
        private readonly IMap map;

        public Controller()
        {
            this.gunRepository = new GunRepository();
            this.playerRepository = new PlayerRepository();
            this.map = new Map();
        }

        public string AddGun(string type, string name, int bulletsCount)
        {
            if (type != nameof(Pistol) && type != nameof(Rifle))
            {
                throw new ArgumentException(ExceptionMessages.InvalidGunType);
            }

            if (type == nameof(Pistol))
            {
                this.gunRepository.Add(new Pistol(name, bulletsCount));
            }
            else
            {
                this.gunRepository.Add(new Rifle(name, bulletsCount));
            }

            return string.Format(OutputMessages.SuccessfullyAddedGun, name);
        }

        public string AddPlayer(string type, string username, int health, int armor, string gunName)
        {
            IGun gun = this.gunRepository.FindByName(gunName);

            if (gun == null)
            {
                throw new ArgumentException(ExceptionMessages.GunCannotBeFound);
            }

            if (type != nameof(Terrorist) && type != nameof(CounterTerrorist))
            {
                throw new ArgumentException(ExceptionMessages.InvalidPlayerType);
            }

            if (type == nameof(Terrorist))
            {
                this.playerRepository.Add(new Terrorist(username, health, armor, gun));
            }
            else
            {
                this.playerRepository.Add(new CounterTerrorist(username, health, armor, gun));
            }

            return string.Format(OutputMessages.SuccessfullyAddedPlayer, username);
        }

        public string Report()
        {
            StringBuilder stringBuilder = new StringBuilder();

            foreach (var player in this.playerRepository.Models.OrderBy(x=>x.GetType().Name).ThenByDescending(x=>x.Health).ThenBy(x=>x.Username))
            {
                stringBuilder.Append($"{player.GetType().Name}: {player.Username}\n");
                stringBuilder.Append($"--Health: {player.Health}\n");
                stringBuilder.Append($"--Armor: {player.Armor}\n");
                stringBuilder.Append($"--Gun: {player.Gun.Name}\n");
            }

            return stringBuilder.ToString().TrimEnd();
        }

        public string StartGame()
        {
            ICollection<IPlayer> players = this.playerRepository.Models.ToList();

            return this.map.Start(players);
        }
    }
}
