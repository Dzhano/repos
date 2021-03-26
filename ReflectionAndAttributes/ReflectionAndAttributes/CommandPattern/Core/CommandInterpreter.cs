using CommandPattern.Core.Commands;
using CommandPattern.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace CommandPattern.Core
{
    public class CommandInterpreter : ICommandInterpreter
    {
        public string Read(string args)
        {
            string[] parts = args.Split();

            Type type = Assembly.GetEntryAssembly().GetTypes().FirstOrDefault(t => t.Name == $"{parts[0]}Command");
            if (type == null)
                throw new ArgumentException();

            /*switch (parts[0])
            {
                case "Hello":
                    command = new HelloCommand();
                    break;
                case "Exit":
                    command = new ExitCommand();
                    break;
            }*/

            ICommand command = (ICommand) Activator.CreateInstance(type);
            string[] commandArgs = parts.Skip(1).ToArray();
            return command.Execute(commandArgs);
        }
    }
}
