using System;
using System.Linq;
using System.Collections.Generic;

namespace Raiding
{
    public class StartUp
    {
        public static void Main()
        {
            int countOfHeroes = int.Parse(Console.ReadLine());
            List<BaseHero> heroes = new List<BaseHero>();
            int counter = 0;

            while (counter < countOfHeroes)
            {
                string name = Console.ReadLine();
                string type = Console.ReadLine();

                if (type != nameof(Druid) && type != nameof(Paladin) && type != nameof(Rogue) && type != nameof(Warrior))
                {
                    Console.WriteLine("Invalid hero!");
                }
                else
                {
                    HeroCreater(name, type, heroes);
                    counter++;
                }
            }

            int bossPower = int.Parse(Console.ReadLine());

            foreach (var hero in heroes)
            {
                Console.WriteLine(hero.CastAbility());
            }

            if (bossPower > heroes.Sum(x => x.Power))
            {
                Console.WriteLine("Defeat...");
            }
            else
            {
                Console.WriteLine("Victory!");
            }
        }

        public static void HeroCreater(string name, string type, List<BaseHero> heroes)
        {
            if(type == nameof(Druid))
            {
                heroes.Add(new Druid(name));
            }
            else if (type == nameof(Paladin))
            {
                heroes.Add(new Paladin(name));
            }
            else if (type == nameof(Rogue))
            {
                heroes.Add(new Rogue(name));
            }
            else if (type == nameof(Warrior))
            {
                heroes.Add(new Warrior(name));
            }
        }
    }
}
