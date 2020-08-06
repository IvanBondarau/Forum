using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Forum.Models;
using Forum.Services;
using Microsoft.AspNetCore.Mvc;

namespace Forum.Controllers
{
    public class TopicController : Controller
    {
        private readonly ITopicService _topicService;
        
        public TopicController(ITopicService topicService)
        {
            this._topicService = topicService;
        }
        
        public string Index()
        {
            return String.Join("\n", _topicService.GetTopics());
        }

        public string GetBySection(string sectionName)
        {
            Section section = new Section(sectionName);
            return String.Join("\n", _topicService.GetTopicsBySection(section));
        }
    }
}
