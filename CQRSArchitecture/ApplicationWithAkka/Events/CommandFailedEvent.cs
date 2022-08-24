namespace ApplicationWithAkka.Events
{
    using ApplicationWithAkka.Interfaces;
    using System;

    public class CommandFailedEvent : IEvent
    {
        public Guid Id { get; set; }

        public string Message { get; set; }
    }
}
