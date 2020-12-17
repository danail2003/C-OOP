using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Planets;
using System.Collections.Generic;
using System.Linq;

namespace SpaceStation.Models.Mission
{
    public class Mission : IMission
    {
        public void Explore(IPlanet planet, ICollection<IAstronaut> astronauts)
        {
            while (true)
            {
                IAstronaut currentAstronaut = astronauts.FirstOrDefault(x => x.CanBreath);

                if (currentAstronaut == null)
                {
                    break;
                }

                while (planet.Items.Count > 0)
                {
                    string item = planet.Items.FirstOrDefault();

                    currentAstronaut.Breath();
                    currentAstronaut.Bag.Items.Add(item);
                    planet.Items.Remove(item);

                    if (!currentAstronaut.CanBreath)
                    {
                        break;
                    }
                }

                if (planet.Items.Count == 0)
                {
                    break;
                }
            }
        }
    }
}
