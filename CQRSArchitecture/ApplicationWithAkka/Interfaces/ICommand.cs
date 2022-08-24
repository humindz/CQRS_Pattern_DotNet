namespace ApplicationWithAkka.Interfaces
{
    using System;

    public interface ICommand
    {
        /// <summary>
        /// Identifier of the command.
        /// </summary>
        Guid Id { get; set; }
    }
}
