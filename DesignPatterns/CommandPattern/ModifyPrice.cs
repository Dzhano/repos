using System;
using System.Collections.Generic;
using System.Text;

namespace CommandPattern
{
    public class ModifyPrice
    {
        private readonly List<ICommand> commands;
        private ICommand command;

        public ModifyPrice()
        {
            commands = new List<ICommand>();
        }

        public void SetCommand(ICommand _command) => command = _command;

        public void Invoke()
        {
            commands.Add(command);
            command.ExecuteAction();
        }
    }
}
