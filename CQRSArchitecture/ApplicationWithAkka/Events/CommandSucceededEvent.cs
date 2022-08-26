using ApplicationWithAkka.Interfaces;

namespace ApplicationWithAkka.Events
{
    public class CommandSucceededEvent : IEvent
    {
        public IAkkaCommand Command { get; set; }
    }
}
