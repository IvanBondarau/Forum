using Forum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.Services
{
    public interface ISectionService: ICrudService<Section, int>
    {
        Section FindByName(string Name);
    }
}
