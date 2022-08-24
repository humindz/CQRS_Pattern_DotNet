namespace InfrastructureWithAkka
{
    using Akka.Actor;
    using ApplicationWithAkka.Commands.AddNewProduct;
    using ApplicationWithAkka.Events;
    using ApplicationWithAkka.Interfaces;
    using System;
    using System.Collections.Generic;

    public class CommandProcessorActor : ReceiveActor
    {
        private readonly Dictionary<Type, ICommandHandler<ICommand>> commandHandlers =
            new Dictionary<Type, ICommandHandler<ICommand>>
            {
                {
                    typeof(AddNewProductCommand), new AddNewProductCommandHandler() as ICommandHandler<ICommand>
                }
            };

        public CommandProcessorActor()
        {
            Receive<ICommand>(ForwardCommand);
        }

        private void ForwardCommand(ICommand command)
        {
            var commandType = command.GetType();

            if (commandHandlers.ContainsKey(commandType))
            {
                commandHandlers[commandType].ExecuteCommand(command);
            }
            else
            {
                Context.System.EventStream.Publish(new CommandFailedEvent
                {
                    Id = command.Id,
                    Message = "No command handler found for command"
                });
            }
        }
    }
}
