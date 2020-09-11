using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Forum.Models;
using Forum.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Forum.Controllers
{
    public class SectionController : Controller
    {
        private readonly ISectionService _sectionService;

        public SectionController(ISectionService sectionService)
        {
            _sectionService = sectionService;
        }

        public IActionResult Index()
        {
            ViewData["Sections"] = _sectionService.FindAll();
            ViewData["Test"] = "Test";
            return View();
        }


        public string Details(int id)
        {
            return _sectionService.Read(id).ToString();
        }

        public string Details(string name)
        {
            Section searchResult = _sectionService.FindByName(name);
            if (searchResult == null)
            {
                return "Not found";
            }
            return searchResult.ToString();
        }

        [HttpPost]
        public string Create(Section section)
        {
            return _sectionService.Create(section).ToString();
        }

        [HttpPost]
        public string Update(int id, Section section)
        {
            section.Id = id;
            _sectionService.Update(section);
            return section.ToString();
        }

        public string Delete(int id)
        {
            _sectionService.Delete(id);
            return "OK";
        }
    }
}
