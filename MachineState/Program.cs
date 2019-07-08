using MachineState.Commands;
using System;
using System.Collections.Generic;

namespace MachineState
{
    class Program
    {
        static void Main(string[] args)
        {
            Process p = new Process();
            Console.WriteLine("Current State = " + p.CurrentState);



            Console.WriteLine("Command.Begin: Current State = " + p.MoveNext(new CommandOne()));
            Console.WriteLine("Command.Pause: Current State = " + p.MoveNext(new CommandTwo()));
            Console.WriteLine("Command.End: Current State = " + p.MoveNext(new CommandSecond()));
            Console.ReadLine();
        }
    }
}
