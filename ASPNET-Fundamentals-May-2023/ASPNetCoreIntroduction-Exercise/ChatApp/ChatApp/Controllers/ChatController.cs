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

            //TODO: implement the logic
            var chatModel = new ChatViewModel()
            {
                
            };
        }

        [HttpPost]
        public IActionResult Send()
        {

        }
    }
}
