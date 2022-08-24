namespace ApplicationWithMediatR.Interfaces
{
    using System.Collections.Generic;

    public interface IResult
    {
    }

    public interface IListResult : ICollection<IResult>
    {
    }
}
