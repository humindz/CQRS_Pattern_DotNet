using Akka.Actor;
using ApplicationWithAkka.Interfaces;
using InfrastructureWithAkka.CQRS;
using System;
using System.Reactive.Subjects;

namespace InfrastructureWithAkka.EventHub
{
    public class EventHub : IEventHub, IDisposable
    {
        private readonly IActorSystemProvider actorSystemProvider;

        private Subject<object> subject = new Subject<object>();
        private readonly IActorRef eventProxyActor;

        public EventHub(IActorSystemProvider actorSystemProvider)
        {
            this.actorSystemProvider = actorSystemProvider;

            eventProxyActor = actorSystemProvider.CqrsActorSystem.ActorOf(Props.Create(() => new EventProxyActor(subject)));
            actorSystemProvider.CqrsActorSystem.EventStream.Subscribe(eventProxyActor, typeof(IEvent));
        }

        public void Dispose()
        {
            if (eventProxyActor is null)
            {
                subject?.Dispose();
            }
            else
            {
                actorSystemProvider.CqrsActorSystem.Stop(eventProxyActor);
            }

            subject = null;
        }
    }
}
