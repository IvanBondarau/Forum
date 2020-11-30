using Forum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.ViewModel
{
    public class TopicListViewModel
    {
        public int PageNumber { get; set; }
        public int TotalPages { get; set; }
        public ICollection<Topic> Topics { get; set; }
       

        public TopicListViewModel(ICollection<Topic> topics, int pageNumber, int totalPages)
        {
            PageNumber = pageNumber;
            TotalPages = totalPages;
            Topics = topics;

        }
    }
}
