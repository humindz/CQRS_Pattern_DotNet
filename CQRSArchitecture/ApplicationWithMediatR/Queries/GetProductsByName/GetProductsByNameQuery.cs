namespace ApplicationWithMediatR.Queries.GetProductsByName
{
    using ApplicationWithMediatR.ViewModels;
    using MediatR;
    using System.Collections.Generic;

    public class GetProductsByNameQuery : IRequest<List<ProductMediatRViewModel>> 
    {
        public string Name { get; set; }
    }
}
