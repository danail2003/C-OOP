using System;

namespace FootballTeamGenerator
{
    public class Player
    {
        private string name;
        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;

        public Player(string name, int endurance, int sprint, int dribble, int passing, int shooting)
        {
            this.Name = name;
            this.Endurance = endurance;
            this.Sprint = sprint;
            this.Dribble = dribble;
            this.Passing = passing;
            this.Shooting = shooting;
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if(string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception("A name should not be empty.");
                }

                this.name = value;
            }
        }

        private int Endurance
        {
            set
            {
                if(value < 0 || value > 100)
                {
                    throw new Exception("Endurance should be between 0 and 100.");
                }

                this.endurance = value;
            }
        }

        private int Sprint
        {
            set
            {
                if(value < 0 || value > 100)
                {
                    throw new Exception("Sprint should be between 0 and 100.");
                }

                this.sprint = value;
            }
        }

        private int Dribble
        {
            set
            {
                if(value < 0 || value > 100)
                {
                    throw new Exception("Dribble should be between 0 and 100.");
                }

                this.dribble = value;
            }
        }

        private int Passing
        {
            set
            {
                if(value < 0 || value > 100)
                {
                    throw new Exception("Passing should be between 0 and 100.");
                }

                this.passing = value;
            }
        }

        private int Shooting
        {
            set
            {
                if(value < 0 || value > 100)
                {
                    throw new Exception("Shooting should be between 0 and 100.");
                }

                this.shooting = value;
            }
        }

        public int CalculatingPlayerStats()
        {
            return (int)Math.Round((this.endurance + this.dribble + this.sprint + this.passing + this.shooting) / 5.0);
        }

        public int Stats()
        {
            return CalculatingPlayerStats();
        }
    }
}
