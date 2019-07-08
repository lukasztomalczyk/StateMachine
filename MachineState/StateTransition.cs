using System;
using System.Collections.Generic;
using System.Text;

namespace MachineState
{
    class StateTransition
    {
        readonly ProcessState CurrentState;
        readonly string Command;

        public StateTransition(ProcessState currentState, ICommand command)
        {
            CurrentState = currentState;
            Command = command.GetType().FullName;
        }

        public override int GetHashCode()
        {
            return 17 + 31 * CurrentState.GetHashCode() + 31 * Command.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            StateTransition other = obj as StateTransition;
            return other != null && this.CurrentState == other.CurrentState && this.Command == other.Command;
        }
    }
}
