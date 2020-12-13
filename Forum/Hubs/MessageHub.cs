using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.Hubs
{
    public class MessageHub: Hub
    {
        
        public void SendMessageUpdated(int messageId, int likes)
        {
            Clients.All.SendAsync("UpdateMessage", messageId, likes);
        }
        
    }
}
