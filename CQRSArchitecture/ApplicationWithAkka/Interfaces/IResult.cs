using System.Collections.Generic;

namespace ApplicationWithAkka.Interfaces
{

    public interface IResult
    {
    }

    public interface IListResult : ICollection<IResult>
    {
    }
}
