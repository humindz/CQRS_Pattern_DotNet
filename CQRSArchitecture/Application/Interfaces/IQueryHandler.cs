using System.Collections.Generic;

namespace Application.Interfaces
{
    public interface IQuery
    {
    }

    public interface IQueryHandler
    {
    }

    public interface IQueryHandler<in T> : IQueryHandler where T : IQuery
    {
        IList<IResult> Handle(T query);
        
    }

    public interface IQueryDispatcher
    {
        IList<IResult> Send<T>(T query) where T : IQuery;
    }
}
