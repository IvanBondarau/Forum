using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Forum.Hubs;
using Forum.Services;
using Forum.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace Forum.Controllers
{
    public class MessageController : Controller
    {
        private readonly IMessageService messageService;
        private readonly IHubContext<TopicHub> hubContext;

        public MessageController(IMessageService messageService, IHubContext<TopicHub> hubContext)
        {
            this.messageService = messageService;
            this.hubContext = hubContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(MessageCreateViewModel messageCreateViewModel)
        {
            messageService.Create(messageCreateViewModel.TopicId, messageCreateViewModel.AuthorId, messageCreateViewModel.Text);

            hubContext.Clients.All.SendAsync("UpdateTopic");

            return RedirectToAction("Details", "Topic", new { id = messageCreateViewModel.TopicId });
        }

        [HttpPost]
        public void Like(int id)
        {
            messageService.Like(id, User.Identity.Name);
        }

        [HttpDelete]
        public void Delete(int id)
        {
            messageService.Delete(id);
        }
    }
}
