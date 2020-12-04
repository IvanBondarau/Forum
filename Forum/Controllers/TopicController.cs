using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Forum.Hubs;
using Forum.Models;
using Forum.Services;
using Forum.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Forum.Controllers
{
    public class TopicController : Controller
    {
        private readonly ITopicService topicService;
        private readonly IUserService userService;
        private readonly IMessageService messageService;

        public TopicController(ITopicService topicService, IMessageService messageService, IUserService userService)
        {
            this.topicService = topicService;
            this.messageService = messageService;
            this.userService = userService;
        }

        // GET: TopicController
        public ActionResult Index(int? page)
        {
            page = page == null ? 1 : (int)page;
            ICollection<Topic> topics = topicService.FindPage(page);
            return View(new TopicListViewModel(topics, page ?? 1, topicService.CountPages()));
        }

        // GET: TopicController/Details/5
        public ActionResult Details(int id, int? page)
        {
            User user = userService.GetByUsername(User.Identity.Name);
            Topic topic = topicService.Read(id);
            ICollection<Message> messages = messageService.FindByTopicId(id, page);
            return View(new MessageListViewModel(topic, messages, user, page ?? 1, messageService.CountPages()));
        }

        // GET: TopicController/Create
        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Featured(int? page)
        {
            ICollection<Topic> topics = topicService.FindFeatured(User.Identity.Name, page);
            return View("Index",new TopicListViewModel(topics, page ?? 1, topicService.CountPages()));
        }

        public ActionResult Feature(int id)
        {
            Topic topic = topicService.Read(id);
            userService.Feature(User.Identity.Name, topic);
            return RedirectToAction("Featured", "Topic");

        }

        public ActionResult Like(int id)
        {
            Message message = messageService.Read(id);
            userService.Like(User.Identity.Name, message);
            return RedirectToAction("Index", "Topic");

        }

        // POST: TopicController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TopicCreateViewModel topicCreateViewModel)
        {
            User currentUser = userService.GetByUsername(User.Identity.Name);

            Topic topic = new Topic(
                topicCreateViewModel.Name,
                topicCreateViewModel.Description,
                ParseLabels(topicCreateViewModel.Labels),
                currentUser
            );

            Topic created = topicService.Create(topic);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Search(TopicSearchViewModel topicSearchViewModel)
        {
            return RedirectToAction("Search", "Topic", new { name = topicSearchViewModel.Name, labels = topicSearchViewModel.Labels });
        }

        public ActionResult Search(int? page)
        {
            string name = Request.Query["name"];
            ICollection<Label> labels = ParseLabels(Request.Query["labels"]);
            ICollection<Topic> searchResult = topicService.Find(name, labels, page);
            return View("Index", new TopicListViewModel(searchResult, page ?? 1, topicService.CountPages()));
        }

        // GET: TopicController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TopicController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            topicService.Delete(id);
            return RedirectToAction("Index", "Topic");
        }


        private ICollection<Label> ParseLabels(string labelString)
        {
            if (labelString == null)
            {
                return new List<Label>();
            } else
            {
                return labelString.Split(';').Select(name => new Label(name)).ToList();
            }
        }
    }
}
