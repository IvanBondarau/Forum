using Forum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.Services.Implementatios
{
    public class SectionService
        : InMemoryCrudService<Section>, ISectionService
    {
        public Section FindByName(string name)
        {
            return _items.First<Section>(item => item.Name == name);
        }
    }
}
