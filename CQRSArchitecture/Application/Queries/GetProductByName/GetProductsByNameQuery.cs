using Application.Interfaces;

namespace Application.Queries.GetProductByName
{
    public class GetProductsByNameQuery : IQuery
    {
        public string Name { get; set; }
    }
}
