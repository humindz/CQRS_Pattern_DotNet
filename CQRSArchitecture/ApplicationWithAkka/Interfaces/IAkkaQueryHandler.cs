namespace ApplicationWithAkka.Interfaces
{
    public interface IAkkaQueryHandler<in TQuery> where TQuery : IAkkaQuery
    {
        public void ExecuteQuery(TQuery query);
    }
}
