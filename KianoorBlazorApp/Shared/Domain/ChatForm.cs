using System.ComponentModel.DataAnnotations;

namespace KianoorBlazorApp.Domain
{
    public class ChatForm
    {
        [Required(ErrorMessage = "Nothing to say?")]
        public string MessageInput { get; set; }
        [Required]
        public ChatUser CurrentUser { get; set; } = new ChatUser();
    }
}
