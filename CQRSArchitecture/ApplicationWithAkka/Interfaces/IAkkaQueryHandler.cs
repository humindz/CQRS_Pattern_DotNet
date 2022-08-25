namespace ApplicationWithAkka.Interfaces
{
    using System.Collections.Generic;

    public interface IAkkaQueryHandler<in TQuery> where TQuery : IAkkaQuery
    {
        public void ExecuteQuery(TQuery query);
    }
}
