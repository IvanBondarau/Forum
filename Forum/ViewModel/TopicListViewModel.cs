using Forum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.ViewModel
{
    public class TopicListViewModel
    {

        public ICollection<Topic> Topics { get; set; }

        public TopicListViewModel(ICollection<Topic> topics)
        {
            Topics = topics;
        }
    }
}
