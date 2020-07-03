using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
