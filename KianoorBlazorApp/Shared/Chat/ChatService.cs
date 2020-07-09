//using Microsoft.AspNetCore.Components;
//using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.SignalR.Client;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using KianoorBlazorApp.Domain;
using KianoorBlazorApp.Domain.ChatElements;

namespace KianoorBlazorApp.Shared.Services
{

    public interface IChatService
    {
        public ChatForm ChatForm { get; set; }
        public Task Send();
        public Task Join();
        public bool IsConnected();
        public List<ChatElement> AllMessages { get; set; }
        public HubConnection HubConnection { get; set; }
        public bool HasSentMsg { get; set; }
    }

    public class ChatService : IChatService
    {
        public const string HUBURL = "/PremiumChatHub";

        public ChatForm ChatForm { get; set; } = new ChatForm();
        public HubConnection HubConnection { get; set; }
        public List<ChatElement> AllMessages { get; set; }
        public bool HasSentMsg { get; set; } = false; // has user sent at least one message?


        public ChatService()
        {
            this.AllMessages = new List<ChatElement>();
        }

        public Task Join() => HubConnection.SendAsync("SystemMsg",
                $"{ChatForm.CurrentUser.EMail ?? "Guest"} has joined the conversation.", MsgPriority.LOW
                );

        public Task Send()
        {
            HasSentMsg = true;

            var res = HubConnection.SendAsync("BroadcastMsg",
                JsonSerializer.Serialize(ChatForm.CurrentUser),
                ChatForm.MessageInput);
            
            ChatForm.MessageInput = "";
            return res;
        }

        public bool IsConnected()
        {
            return HubConnection.State == HubConnectionState.Connected;
        }



    }
}
