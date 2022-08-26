using ApplicationWithMediatR.ViewModels;
using MediatR;
using System.Collections.Generic;

namespace ApplicationWithMediatR.Queries.GetProductsByName
{
    public class GetProductsByNameQuery : IRequest<List<ProductMediatRViewModel>> 
    {
        public string Name { get; set; }
    }
}
