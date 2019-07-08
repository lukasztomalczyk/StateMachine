using System;
using System.Collections.Generic;
using System.Text;

namespace MachineState.Handlers
{
    public interface ICommandHandler<T> where T : ICommand
    {
        void Handle(T command);
    }
}
