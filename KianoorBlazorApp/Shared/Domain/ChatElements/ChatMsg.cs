using System.Collections.Generic;
using KianoorBlazorApp.Domain.ChatElements;

namespace KianoorBlazorApp.Domain
{
    public class ChatMsg : ChatElement
    {
        public ChatMsg(ChatUser User, List<string> Messages) : base(User, Messages)
        {
        }
    }
}
