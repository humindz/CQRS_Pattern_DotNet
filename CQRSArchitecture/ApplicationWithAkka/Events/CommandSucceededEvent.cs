namespace ApplicationWithAkka.Events
{
    using ApplicationWithAkka.Interfaces;
    using System;

    public class CommandSucceededEvent : IEvent
    {
        public Guid Id { get; set; }
    }
}
