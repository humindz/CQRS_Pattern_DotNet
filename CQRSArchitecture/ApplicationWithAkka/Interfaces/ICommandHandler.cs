namespace ApplicationWithAkka.Interfaces
{
    using ApplicationWithAkka.Commands;

    public interface ICommandHandler<in TCommand> where TCommand : ICommand
    {
        /// <summary>
        /// This method is called to execute a command. Semantically command execution leads to state changes
        /// </summary>
        /// <param name="command">Command to execute</param>
        public void ExecuteCommand(TCommand command);
    }
}
