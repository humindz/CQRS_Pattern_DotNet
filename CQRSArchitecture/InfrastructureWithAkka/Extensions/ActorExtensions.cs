using Akka.Actor;
using InfrastructureWithAkka.CQRS;
using System;
using System.Linq.Expressions;

namespace InfrastructureWithAkka.Extensions
{
    public static class ActorExtensions
    {
        public static IActorRef InitializeActor<TActor>(this IActorSystemProvider actorSystemProvider, Expression<Func<TActor>> factory, string actorName) where TActor : ActorBase
        {
            var queryProcessorActorProps = Props.Create(factory);
            return actorSystemProvider
                .CqrsActorSystem
                .ActorOf(queryProcessorActorProps, actorName);
        }
    }
}
