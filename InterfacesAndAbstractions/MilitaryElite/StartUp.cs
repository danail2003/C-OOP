using System;
using System.Linq;
using System.Collections.Generic;

namespace MilitaryElite
{
    public class StartUp
    {
        public static void Main()
        {
            List<Private> privates = new List<Private>();
            Corps corps;

            while (true)
            {
                string[] token = Console.ReadLine().Split();

                if (token[0] == "End")
                {
                    break;
                }

                if (token[0] == "Private")
                {
                    Private privatee = new Private(token[1], token[2], token[3], decimal.Parse(token[4]));
                    privates.Add(privatee);
                    Console.WriteLine(privatee.ToString());
                }
                else if(token[0] == "LieutenantGeneral")
                {
                    LieutenantGeneral lieutenantGeneral = new LieutenantGeneral(token[1], token[2], token[3], decimal.Parse(token[4]));

                    if (token.Length >= 5)
                    {
                        for (int i = 5; i < token.Length; i++)
                        {
                            string privateId = token[i];
                            Private privatee = privates.FirstOrDefault(x => x.Id == privateId);
                            lieutenantGeneral.Privates.Add(privatee);
                        }
                    }

                    Console.WriteLine(lieutenantGeneral.ToString());
                }
                else if (token[0] == "Engineer")
                {
                    if(Enum.TryParse(token[5], out corps))
                    {
                        Engineer engineer = new Engineer(token[1], token[2], token[3], decimal.Parse(token[4]), corps);

                        if (token.Length >= 6)
                        {
                            for (int i = 6; i < token.Length; i += 2)
                            {
                                string repairPartName = token[i];
                                int repairPartHours = int.Parse(token[i + 1]);

                                Repair repair = new Repair(repairPartName, repairPartHours);
                                engineer.Repairs.Add(repair);
                            }
                        }

                        Console.WriteLine(engineer.ToString());
                    }
                }
                else if (token[0] == "Commando")
                {
                    if(Enum.TryParse(token[5], out corps))
                    {
                        Commando commando = new Commando(token[1], token[2], token[3], decimal.Parse(token[4]), corps);

                        if (token.Length >= 6)
                        {
                            for (int i = 6; i < token.Length; i += 2)
                            {
                                string missionName = token[i];
                                string missionProgress = token[i + 1];

                                if(Enum.TryParse(missionProgress, out MissionState missionState))
                                {
                                    Mission mission = new Mission(missionName, missionState);
                                    commando.Missions.Add(mission);
                                }
                            }

                            Console.WriteLine(commando.ToString());
                        }
                    }
                }
                else if (token[0] == "Spy")
                {
                    Spy spy = new Spy(token[1], token[2], token[3], int.Parse(token[4]));
                    Console.WriteLine(spy);
                }
                else
                {
                    throw new ArgumentException("Invalid Type of Soldier!");
                }
            }
        }
    }
}
