using System;

namespace P03_StudentSystem
{
    class StartUp
    {
        static void Main()
        {
            StudentSystem studentSystem = new StudentSystem();

            while (true)
            {
                string[] command = Console.ReadLine().Split();
                studentSystem.CreateOrShow(command);
            }
        }
    }
}
