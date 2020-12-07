using System;
using System.Linq;
using System.Collections.Generic;

namespace FootballTeamGenerator
{
    class StartUp
    {
        static void Main(string[] args)
        {
            List<Team> teams = new List<Team>();

            while (true)
            {
                string[] token = Console.ReadLine().Split(";");

                if (token[0] == "END")
                {
                    break;
                }

                try
                {
                    if (token[0] == "Team")
                    {
                        teams.Add(new Team(token[1]));
                    }
                    else if (token[0] == "Add")
                    {
                        if (!teams.Any(x => x.Name == token[1]))
                        {
                            throw new Exception($"Team {token[1]} does not exist.");
                        }
                        else
                        {
                            Team currentTeam = teams.FirstOrDefault(x => x.Name == token[1]);
                            currentTeam.Add(new Player(token[2], int.Parse(token[3]), int.Parse(token[4]), int.Parse(token[5]), int.Parse(token[6]), int.Parse(token[7])));
                        }
                    }
                    else if (token[0] == "Remove")
                    {
                        var team2 = teams.First(x => x.Name == token[1]);
                        team2.Remove(token[2]);
                    }
                    else if (token[0] == "Rating")
                    {
                        if (!teams.Any(x => x.Name == token[1]))
                        {
                            throw new Exception($"Team {token[1]} does not exist.");
                        }
                        else
                        {
                            Team currentTeam = teams.First(x => x.Name == token[1]);
                            Console.WriteLine($"{currentTeam.Name} - {currentTeam.Rating}");
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
