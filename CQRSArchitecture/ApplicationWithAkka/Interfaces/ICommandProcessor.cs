using System.Threading.Tasks;

namespace ApplicationWithAkka.Interfaces
{
    public interface ICommandProcessor
    {
        void ProcessCommand(ICommand command);
    }
}
