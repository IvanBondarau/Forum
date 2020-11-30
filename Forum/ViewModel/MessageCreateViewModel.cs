using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.ViewModel
{
    public class MessageCreateViewModel
    {
        public int TopicId { get; set; }
        public int AuthorId { get; set; }
        public string Text { get; set; }
    }
}
