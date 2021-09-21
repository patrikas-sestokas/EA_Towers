using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace EATowers.Hubs
{
    public class CommHub : Hub
    {
        public async Task SendMessage(string user, string message)
        {
            Debug.WriteLine(message);
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
}