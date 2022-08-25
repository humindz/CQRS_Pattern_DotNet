namespace ApplicationWithAkka.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IAkkaQueryProcessor
    {
        Task<List<IResult>> ProcessQuery(IAkkaQuery query);
    }
}
