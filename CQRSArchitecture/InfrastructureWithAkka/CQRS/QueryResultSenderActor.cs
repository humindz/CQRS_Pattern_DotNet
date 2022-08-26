using Akka.Actor;
using ApplicationWithAkka.Interfaces;
using InfrastructureWithAkka.SignalR;
using Microsoft.AspNetCore.SignalR;
using System.Collections.Generic;

namespace InfrastructureWithAkka.CQRS
{
    public class QueryResultSenderActor : ReceiveActor
    {
        private readonly IHubContext<ResultHub> hub;

        public QueryResultSenderActor(IHubContext<ResultHub> hub)
        {
            this.hub = hub;
            Receive<IList<IResult>>(SendResult);
        }

        private void SendResult(IList<IResult> result)
        {
            this.hub.Clients.All.SendAsync("TransferQueryResult", result);
        }
    }
}
