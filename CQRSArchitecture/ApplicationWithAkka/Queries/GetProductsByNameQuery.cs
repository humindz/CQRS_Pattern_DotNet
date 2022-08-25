using ApplicationWithAkka.Interfaces;

namespace ApplicationWithAkka.Queries
{
    public class GetProductsByNameQuery : IAkkaQuery
    {
        public string Name { get; set; }
    }
}
