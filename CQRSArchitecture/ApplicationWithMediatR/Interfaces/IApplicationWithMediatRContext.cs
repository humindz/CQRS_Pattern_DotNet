namespace ApplicationWithMediatR.Interfaces
{
    using Domain;
    using System.Collections.Generic;

    public interface IApplicationWithMediatRContext
    {
        public IList<Product> Products { get; set; }
    }
}
