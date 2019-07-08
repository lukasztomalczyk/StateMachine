using MachineState.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace MachineState.Handlers
{
    public class CommandOneHandler : ICommandHandler<CommandOne>
    {
        public void Handle(CommandOne command)
        {
            Console.
                WriteLine("Command: " + command.GetType().FullName);
        }
    }
}
