using System;
using System.Collections.Generic;
using Application.Exceptions;
using Application.Interfaces;

namespace Application.Queries
{
    public class QueryDispatcher : IQueryDispatcher
    {
        private readonly IServiceProvider serviceProvider;

        public QueryDispatcher(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public IList<IResult> Send<T>(T query) where T : IQuery
        {
            var handler = serviceProvider.GetService(typeof(IQueryHandler<T>));
            if (handler != null)
                return ((IQueryHandler<T>)handler).Handle(query);
            else
                throw new NotFoundException($"Query doesn't have any handler {query.GetType().Name}");
            
        }
    }
}
