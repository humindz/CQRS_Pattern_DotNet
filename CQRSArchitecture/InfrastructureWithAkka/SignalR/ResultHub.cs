using Microsoft.AspNetCore.SignalR;
using ApplicationWithAkka.Interfaces;
using System.Collections.Generic;

namespace InfrastructureWithAkka.SignalR
{
    public class ResultHub : Hub<IList<IResult>>
    {
    }
}
