using MachineState.Commands;
using MachineState.Handlers;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace MachineState
{
    public class Process
    {
        private Dictionary<StateTransition, ProcessState> Transitions { get; set; }
        public ServiceProvider Service { get; }
        public ProcessState CurrentState { get; private set; }


        public Process(Dictionary<StateTransition, ProcessState> dictionary, ServiceProvider service)
        {
            Transitions = dictionary;
            Service = service;
            CurrentState = ProcessState.Inactive;
        }

        public ProcessState GetNext(ICommand command)
        {
            StateTransition transition = new StateTransition(CurrentState, command);
            ProcessState nextState;
            if (!Transitions.TryGetValue(transition, out nextState))
                throw new Exception("Invalid transition: " + CurrentState + " -> " + command);
            var handler = Service.GetRequiredService<ICommandHandler<ICommand>>();
            handler.Handle(command);
            return nextState;
        }

        public ProcessState MoveNext(ICommand command)
        {
            CurrentState = GetNext(command);
            return CurrentState;
        }
    }
    }
