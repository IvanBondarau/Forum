using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Forum.Hubs;
using Forum.Models;
using Forum.Services;
using Forum.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace Forum.Controllers
{
    [Authorize]
    [AutoValidateAntiforgeryToken]
    public class MessageController : Controller
    {
        private readonly IMessageService messageService;
        private readonly IHubContext<TopicHub> hubContext;
        private readonly IHubContext<MessageHub> messageContext;

        public MessageController(IMessageService messageService, IHubContext<TopicHub> hubContext,
            IHubContext<MessageHub> messageContext)
        {
            this.messageService = messageService;
            this.hubContext = hubContext;
            this.messageContext = messageContext;
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
        [IgnoreAntiforgeryToken]
        public void Like(int id)
        {
            messageService.Like(id, User.Identity.Name);
            Message message = messageService.Read(id);
            messageContext.Clients.All.SendAsync("UpdateMessage", message.MessageId.ToString(), message.Likes.Count.ToString());

        }

        [HttpDelete]
        [IgnoreAntiforgeryToken]
        public void Delete(int id)
        {
            messageService.Delete(id);
        }
    }
}
