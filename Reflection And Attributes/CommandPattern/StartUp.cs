﻿using CommandPattern.Core.Contracts;
using CommandPattern.Models;

namespace CommandPattern
{
    public class StartUp
    {
        public static void Main()
        {
            ICommandInterpreter command = new CommandInterpreter();
            IEngine engine = new Engine(command);
            engine.Run();
        }
    }
}
