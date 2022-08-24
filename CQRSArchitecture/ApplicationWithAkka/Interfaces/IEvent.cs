namespace ApplicationWithAkka.Interfaces
{
    using System;

    public interface IEvent
    {
        /// <summary>
        /// Identifier of the event.
        /// </summary>
        Guid Id { get; set; }
    }
}
