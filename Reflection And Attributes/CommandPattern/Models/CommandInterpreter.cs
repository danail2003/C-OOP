using System;
using System.Linq;
using System.Reflection;
using CommandPattern.Core.Contracts;

namespace CommandPattern.Models
{
    public class CommandInterpreter : ICommandInterpreter
    {
        private const string command = "Command";

        public string Read(string args)
        {
            string[] token = args.Split(' ', System.StringSplitOptions.RemoveEmptyEntries);
            string[] commands = token.Skip(1).ToArray();

            string commandName = token[0] + command;

            Assembly assembly = Assembly.GetCallingAssembly();
            Type type = assembly.GetTypes().FirstOrDefault(x => x.Name.ToLower() == commandName.ToLower());

            if (type == null)
            {
                throw new ArgumentException("Invalid command type!");
            }

            ICommand concreteCommand = (ICommand)Activator.CreateInstance(type);

            string result = concreteCommand.Execute(commands);

            return result;
        }
    }
}
