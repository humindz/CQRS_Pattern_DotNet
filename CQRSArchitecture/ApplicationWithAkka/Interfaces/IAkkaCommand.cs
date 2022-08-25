using System;

namespace ApplicationWithAkka.Interfaces
{
    public interface IAkkaCommand
    {
        /// <summary>
        /// Identifier of the command.
        /// </summary>
        Guid Id { get; set; }
    }
}
