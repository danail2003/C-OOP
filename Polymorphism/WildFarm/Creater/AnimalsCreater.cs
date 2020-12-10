namespace WildFarm.Creater
{
    using WildFarm.Animals;

    public class AnimalsCreater
    {
        public static Animal CreateAnimal(string[] token)
        {
            string type = token[0];

            if(type == nameof(Owl))
            {
                return new Owl(token[1], double.Parse(token[2]), double.Parse(token[3]));
            }
            else if (type == nameof(Hen))
            {
                return new Hen(token[1], double.Parse(token[2]), double.Parse(token[3]));
            }
            else if (type == nameof(Mouse))
            {
                return new Mouse(token[1], double.Parse(token[2]), token[3]);
            }
            else if (type == nameof(Dog))
            {
                return new Dog(token[1], double.Parse(token[2]), token[3]);
            }
            else if (type == nameof(Cat))
            {
                return new Cat(token[1], double.Parse(token[2]), token[3], token[4]);
            }
            else if (type == nameof(Tiger))
            {
                return new Tiger(token[1], double.Parse(token[2]), token[3], token[4]);
            }

            return null;
        }
    }
}
