using ApplicationWithAkka.Interfaces;

namespace ApplicationWithAkka.Queries
{
    public class GetProductByPriceRangeQuery : IAkkaQuery
    {
        public decimal MinPrice { get; set; }

        public decimal MaxPrice { get; set; }
    }
}
