namespace WildFarm.Creater
{
    using WildFarm.Food;

    public class FoodCreater
    {
        public static Food CreateFood(string[] foodInfo)
        {
            string type = foodInfo[0];

            if (type == nameof(Vegetable))
            {
                return new Vegetable(int.Parse(foodInfo[1]));
            }
            else if (type == nameof(Fruit))
            {
                return new Fruit(int.Parse(foodInfo[1]));
            }
            else if (type == nameof(Meat))
            {
                return new Meat(int.Parse(foodInfo[1]));
            }
            else if (type == nameof(Seeds))
            {
                return new Seeds(int.Parse(foodInfo[1]));
            }

            return null;
        }
    }
}
