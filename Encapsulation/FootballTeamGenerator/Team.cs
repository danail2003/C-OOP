using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace FootballTeamGenerator
{
    public class Team
    {
        private readonly List<Player> team;

        public Team(string name)
        {
            this.Name = name;
            this.team = new List<Player>();
        }

        public string Name { get; set; }

        public void Add(Player player)
        {
            this.team.Add(player);
        }

        public void Remove(string name)
        {
            if (!team.Any(x=>x.Name==name))
            {
                throw new Exception($"Player {name} is not in {this.Name} team.");
            }

            Player player = team.FirstOrDefault(x => x.Name == name);
            this.team.Remove(player);
        }

        public int Rating
        {
            get => CalculatingRating();
        }

        private int CalculatingRating()
        {
            if (this.team.Any())
            {
                return (int)Math.Round(this.team.Average(x => x.Stats()));
            }
            else
            {
                return 0;
            }
        }
    }
}
