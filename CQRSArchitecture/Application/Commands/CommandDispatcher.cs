using System;
using Application.Exceptions;
using Application.Interfaces;

namespace Application.Commands
{
    public class CommandDispatcher : ICommandDispatcher
    {
        private readonly IServiceProvider serviceProvider;

        public CommandDispatcher(IServiceProvider service)
        {
            serviceProvider = service;
        }

        public void Send<T>(T command) where T : ICommand
        {
            var handler = serviceProvider.GetService(typeof(ICommandHandler<T>));
            
            if (handler != null)
                ((ICommandHandler<T>)handler).Handle(command);
            else
                throw new NotFoundException($"Command doesn't have any handler {command.GetType().Name}");

        }
    }
}
