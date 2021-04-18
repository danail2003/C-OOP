namespace CounterStrike.Models.Maps
{
    using System.Linq;
    using System.Collections.Generic;
    using CounterStrike.Models.Maps.Contracts;
    using CounterStrike.Models.Players;
    using CounterStrike.Models.Players.Contracts;

    public class Map : IMap
    {
        public string Start(ICollection<IPlayer> players)
        {
            List<IPlayer> terrorists = players.Where(x => x.GetType().Name == nameof(Terrorist)).ToList();
            List<IPlayer> counterTerrorists = players.Where(x => x.GetType().Name == nameof(CounterTerrorist)).ToList();

            while (terrorists.Any(x => x.IsAlive) && counterTerrorists.Any(x => x.IsAlive))
            {
                foreach (var terrorist in terrorists)
                {
                    if (!terrorist.IsAlive)
                    {
                        continue;
                    }

                    foreach (var counterTerrorist in counterTerrorists)
                    {
                        if (!counterTerrorist.IsAlive)
                        {
                            continue;
                        }

                        counterTerrorist.TakeDamage(terrorist.Gun.Fire());
                    }
                }

                foreach (var counterTerrorist in counterTerrorists)
                {
                    if (!counterTerrorist.IsAlive)
                    {
                        continue;
                    }

                    foreach (var terrorist in terrorists)
                    {
                        if (!terrorist.IsAlive)
                        {
                            continue;
                        }

                        terrorist.TakeDamage(counterTerrorist.Gun.Fire());
                    }
                }
            }

            if (terrorists.Any(x => x.IsAlive))
            {
                return "Terrorist wins!";
            }

            return "Counter Terrorist wins!";
        }
    }
}
