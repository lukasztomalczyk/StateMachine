using MachineState.Commands;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace MachineState
{
    public class Process
    {
        private Dictionary<StateTransition, ProcessState> Transitions { private get;  private set; };
        public ProcessState CurrentState { get; private set; }

        public Process(Dictionary<StateTransition, ProcessState> dictionary)
        {
            Transitions = dictionary;
            CurrentState = ProcessState.Inactive;
        }

        public ProcessState GetNext(ICommand command)
        {
            StateTransition transition = new StateTransition(CurrentState, command);
            ProcessState nextState;
            if (!Transitions.TryGetValue(transition, out nextState))
                throw new Exception("Invalid transition: " + CurrentState + " -> " + command);
            return nextState;
        }

        public ProcessState MoveNext(ICommand command)
        {
            CurrentState = GetNext(command);
            return CurrentState;
        }
    }
    }
