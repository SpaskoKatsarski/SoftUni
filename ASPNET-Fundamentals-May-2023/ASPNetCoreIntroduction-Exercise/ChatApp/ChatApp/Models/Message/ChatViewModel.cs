namespace ChatApp.Models.Message
{
    public class ChatViewModel
    {
        public MessageViewModel CurrentMessage { get; set; } = null!;

        public ICollection<MessageViewModel> Messages { get; set; } = null!;
    }
}
