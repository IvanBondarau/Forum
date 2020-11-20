using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.Exceptions
{
    public class TopicNotFoundException : Exception
    {
        public TopicNotFoundException(string message) : base(message)
        {
        }
    }
}
