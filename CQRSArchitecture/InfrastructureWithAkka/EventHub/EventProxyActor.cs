using Akka.Actor;
using System.Reactive.Subjects;

namespace InfrastructureWithAkka.EventHub
{
    public class EventProxyActor : UntypedActor
    {
        private Subject<object> subject;

        public EventProxyActor(Subject<object> subject)
        {
            this.subject = subject;
        }

        protected override void PostStop()
        {
            subject?.Dispose();
            subject = null;
        }

        protected override void OnReceive(object message)
        {
            subject?.OnNext(message);
        }
    }
}
