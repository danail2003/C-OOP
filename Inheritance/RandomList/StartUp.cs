using System;

namespace CustomRandomList
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            RandomList randomList = new RandomList();
            randomList.Add("Gosho");
            randomList.Add("Pesho");
            randomList.Add("Ivan");
            randomList.Add("Dragan");
            string result = randomList.RandomString();

            Console.WriteLine(result);
        }
    }
}
