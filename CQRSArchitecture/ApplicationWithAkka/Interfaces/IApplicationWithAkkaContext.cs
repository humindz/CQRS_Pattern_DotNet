using Domain;
using System.Collections.Generic;

namespace ApplicationWithAkka.Interfaces
{
    public interface IApplicationWithAkkaContext
    {
        public IList<Product> Products { get; set; }
    }
}
