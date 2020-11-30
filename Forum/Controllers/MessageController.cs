using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Forum.Services;
using Forum.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Forum.Controllers
{
    public class MessageController : Controller
    {
        private readonly IMessageService messageService;

        public MessageController(IMessageService messageService)
        {
            this.messageService = messageService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(MessageCreateViewModel messageCreateViewModel)
        {
            messageService.Create(messageCreateViewModel.TopicId, messageCreateViewModel.AuthorId, messageCreateViewModel.Text);

            return RedirectToAction("Details", "Topic", new { id = messageCreateViewModel.TopicId });
        }
    }
}
