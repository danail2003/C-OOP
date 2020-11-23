using System;
using System.Collections.Generic;
using System.Linq;

namespace GreedyTimes
{

    public class StartUp
    {
        static void Main()
        {
            long capacityOfBag = long.Parse(Console.ReadLine());
            string[] items = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            Dictionary<string, Dictionary<string, long>> bag = new Dictionary<string, Dictionary<string, long>>();

            long gold = 0;
            long gems = 0;
            long cash = 0;

            for (int i = 0; i < items.Length; i += 2)
            {
                string name = items[i];
                long count = long.Parse(items[i + 1]);

                string kindOfItem = string.Empty;

                if (name.Length == 3)
                {
                    kindOfItem = "Cash";
                }
                else if (name.ToLower().EndsWith("gem"))
                {
                    kindOfItem = "Gem";
                }
                else if (name.ToLower() == "gold")
                {
                    kindOfItem = "Gold";
                }

                if (kindOfItem == "")
                {
                    continue;
                }
                else if (capacityOfBag < bag.Values.Select(x => x.Values.Sum()).Sum() + count)
                {
                    continue;
                }

                switch (kindOfItem)
                {
                    case "Gem":
                        if (!bag.ContainsKey(kindOfItem))
                        {
                            if (bag.ContainsKey("Gold"))
                            {
                                if (count > bag["Gold"].Values.Sum())
                                {
                                    continue;
                                }
                            }
                            else
                            {
                                continue;
                            }
                        }
                        else if (bag[kindOfItem].Values.Sum() + count > bag["Gold"].Values.Sum())
                        {
                            continue;
                        }
                        break;
                    case "Cash":
                        if (!bag.ContainsKey(kindOfItem))
                        {
                            if (bag.ContainsKey("Gem"))
                            {
                                if (count > bag["Gem"].Values.Sum())
                                {
                                    continue;
                                }
                            }
                            else
                            {
                                continue;
                            }
                        }
                        else if (bag[kindOfItem].Values.Sum() + count > bag["Gem"].Values.Sum())
                        {
                            continue;
                        }
                        break;
                }

                if (!bag.ContainsKey(kindOfItem))
                {
                    bag[kindOfItem] = new Dictionary<string, long>();
                }

                if (!bag[kindOfItem].ContainsKey(name))
                {
                    bag[kindOfItem][name] = 0;
                }

                bag[kindOfItem][name] += count;

                if (kindOfItem == "Gold")
                {
                    gold += count;
                }
                else if (kindOfItem == "Gem")
                {
                    gems += count;
                }
                else if (kindOfItem == "Cash")
                {
                    cash += count;
                }
            }

            foreach (var item in bag)
            {
                Console.WriteLine($"<{item.Key}> ${item.Value.Values.Sum()}");

                foreach (var kindOfItem in item.Value.OrderByDescending(y => y.Key).ThenBy(y => y.Value))
                {
                    Console.WriteLine($"##{kindOfItem.Key} - {kindOfItem.Value}");
                }
            }
        }
    }
}