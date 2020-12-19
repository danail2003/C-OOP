using System;

namespace Logger
{
    class StartUp
    {
        static void Main()
        {
            int count = int.Parse(Console.ReadLine());
            Controller controller = new Controller();
            controller.Run(count);
        }
    }
}
