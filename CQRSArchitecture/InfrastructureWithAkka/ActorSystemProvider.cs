using System.Threading;
using System.Threading.Tasks;
using Akka.Actor;
using Microsoft.Extensions.Hosting;

namespace InfrastructureWithAkka
{
    public class ActorSystemProvider : IActorSystemProvider, IHostedService
    {
        private ActorSystem actorSystem;
        private readonly IHostApplicationLifetime applicationLifetime;

        public ActorSystemProvider(IHostApplicationLifetime applicationLifetime)
        {
            this.applicationLifetime = applicationLifetime;
        }

        public ActorSystem ActorSystem => actorSystem;

        public Task StartAsync(CancellationToken cancellationToken)
        {
            this.actorSystem = ActorSystem.Create("CQRS");

            this.actorSystem.WhenTerminated.ContinueWith(tr => {
                applicationLifetime.StopApplication();
            }, cancellationToken);


            return Task.CompletedTask;
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            await CoordinatedShutdown.Get(actorSystem).Run(CoordinatedShutdown.ClrExitReason.Instance);
        }
    }
}
