using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.Hubs
{
    public class TopicHub: Hub
    {
        private readonly ILogger<TopicHub> logger;
        public TopicHub(ILogger<TopicHub> logger)
        {
            this.logger = logger;
        }
        public void SendTopicUpdated(int topicId)
        {
            logger.LogInformation("MESSAGESEND");
            Clients.All.SendAsync("UpdateTopic", topicId);
        }
    }
}
