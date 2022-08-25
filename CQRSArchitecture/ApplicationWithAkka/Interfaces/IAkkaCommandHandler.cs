namespace ApplicationWithAkka.Interfaces
{
    public interface IAkkaCommandHandler<in TCommand> where TCommand : IAkkaCommand
    {
        public void ExecuteCommand(TCommand command);
    }
}
