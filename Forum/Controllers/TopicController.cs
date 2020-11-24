using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public TopicController(ITopicService topicService, IUserService userService)
        {
            this.topicService = topicService;
            this.userService = userService;
        }

        // GET: TopicController
        public ActionResult Index(int? page)
        {
            page = page == null ? 1 : (int)page;
            ICollection<Topic> topics = topicService.FindPage(page);
            return View(new TopicListViewModel(topics));
        }

        // GET: TopicController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TopicController/Create
        public ActionResult Create()
        {
            return View();
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

            topicService.Create(topic);

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
            ICollection<Topic> searchResult = topicService.FindTopics(name, labels, page);
            return View(new TopicListViewModel(searchResult));
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

        // GET: TopicController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TopicController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
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
