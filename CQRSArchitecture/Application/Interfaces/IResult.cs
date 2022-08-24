using System.Collections.Generic;

namespace Application.Interfaces
{
    public interface IResult
    {
    }

    public interface IListResult : ICollection<IResult>
    {
    }
}
