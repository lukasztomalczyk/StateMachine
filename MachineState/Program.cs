using MachineState.Commands;
using MachineState.Handlers;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;


namespace MachineState
{
    class Program
    {
        static void Main(string[] args)
        {

            var serviceProvider = new ServiceCollection()
            .AddSingleton<ICommandHandler<CommandOne>, CommandOneHandler>()
            .BuildServiceProvider();


            Process p = new Process(new Dictionary<StateTransition, ProcessState>
            {
                { new StateTransition(ProcessState.Paused, new CommandSecond()), ProcessState.Terminated },
                { new StateTransition(ProcessState.Inactive, new CommandOne()), ProcessState.Active },
                { new StateTransition(ProcessState.Active, new CommandTwo()), ProcessState.Paused },
            }, serviceProvider);
            Console.WriteLine("Current State = " + p.CurrentState);



            Console.WriteLine("Command.Begin: Current State = " + p.MoveNext(new CommandOne()));
            Console.WriteLine("Command.Pause: Current State = " + p.MoveNext(new CommandTwo()));
            Console.WriteLine("Command.End: Current State = " + p.MoveNext(new CommandSecond()));
            Console.ReadLine();
        }

    }
}
