using Microsoft.AspNetCore.Mvc;

using ChatApp.Models.Message;

namespace ChatApp.Controllers
{
    public class ChatController : Controller
    {
        private readonly ICollection<KeyValuePair<string, string>> messages = 
            new List<KeyValuePair<string, string>>();

        public IActionResult Show()
        {
            if (this.messages.Count < 1)
            {
                return View(new ChatViewModel());
            }

            var chatModel = new ChatViewModel()
            {
                Messages = this.messages
                .Select(m => new MessageViewModel()
                {
                    Sender = m.Key,
                    MessageText = m.Value
                })
                .ToList()
            };

            return View(chatModel);
        }

        [HttpPost]
        public IActionResult Send(ChatViewModel chat)
        {
            var newMessage = chat.CurrentMessage;

            this.messages.Add(new KeyValuePair<string, string>
                (newMessage.Sender, newMessage.MessageText));

            return RedirectToAction("Show");
        }
    }
}
