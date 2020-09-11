﻿using Forum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.Services.Implementatios
{
    public class SectionService
        : InMemoryCrudService<Section>, ISectionService
    {
        public SectionService()
        {
            this._items.Add(new Section("Test1"));
            this._items.Add(new Section("Test2"));
        }

        public Section FindByName(string name)
        {
            return _items.First<Section>(item => item.Name == name);
        }
    }
}
