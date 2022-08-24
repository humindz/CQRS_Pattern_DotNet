using System.Collections.Generic;
using Domain;

namespace Application.Interfaces
{
    public interface IApplicationContext
    {
        public IList<Product> Products { get; set; }
    }
}
