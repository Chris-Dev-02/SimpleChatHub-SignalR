using Microsoft.AspNetCore.SignalR;
using SimpleChatroomAPI_SignalR.Models;

namespace SimpleChatroomAPI_SignalR.Hubs
{
    public class ChatHub : Hub
    {
        private readonly ApplicationDbContext _context;

        public ChatHub(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task SendMessage(string user, string message)
        {
            var chatMessage = new Message
            {
                User = user,
                Content = message,
                Timestamp = DateTime.Now
            };
            _context.Messages.Add(chatMessage);
            await _context.SaveChangesAsync();

            // Send messages to all clients connected
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
        /*
        public async Task SendMessage(string user, string message)
        {
            
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
        */
    }
}
