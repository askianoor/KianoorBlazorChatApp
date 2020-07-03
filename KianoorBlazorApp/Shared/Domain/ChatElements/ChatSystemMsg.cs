using System.Collections.Generic;
using KianoorBlazorApp.Domain.ChatElements;

namespace KianoorBlazorApp.Domain
{
    public class ChatSystemMsg : ChatElement
    {
        public static ChatUser SystemUser = new ChatUser("SYSTEM", false);
        public MsgPriority Priority { get; set; }
        

        public ChatSystemMsg(List<string> Messages, MsgPriority Priority) : base(SystemUser, Messages)
        {
            this.Priority = Priority;
        }
       
    }
}
