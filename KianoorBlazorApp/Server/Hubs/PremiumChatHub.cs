using KianoorBlazorApp.Domain;
using KianoorBlazorApp.Shared;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;

namespace KianoorBlazorApp.Server.Hubs
{
    public class PremiumChatHub : Hub
    {
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public override async Task OnConnectedAsync()
        {
            Console.WriteLine($"New connection from {Context.ConnectionId} at {DateTime.Now}");
        }

        public async Task SystemMsg(string message, MsgPriority priority)
        {
            await Clients.Others.SendAsync(IPublic.SYSTEM_MSG, message, priority);
        }

        public async Task BroadcastMsg(string user, string message)
        {
            await Clients.All.SendAsync(IPublic.RECEIVE_MSG, user, message);
        }
    }
}
