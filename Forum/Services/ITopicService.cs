﻿using Forum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.Services
{
    public interface ITopicService : ICrudService<int, Topic>
    {
        Topic FindByName(String name);
        ICollection<Topic> FindPage(int? pageNumber);
        ICollection<Topic> FindTopics(string name, ICollection<Label> labels, int? pageNumber);
    }
}
