namespace ApplicationWithAkka.Interfaces
{
    using System.Collections.Generic;

    public interface IResult
    {
    }

    public interface IListResult : ICollection<IResult>
    {
    }
}
