namespace ApplicationWithAkka.Interfaces
{
    public interface IAkkaCommandProcessor
    {
        void ProcessCommand(IAkkaCommand command);
    }
}
