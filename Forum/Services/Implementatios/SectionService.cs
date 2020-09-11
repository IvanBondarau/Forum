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
        public SectionService()
        {
            this._items.Add(new Section(1, "Test1", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus tempus non ligula ut volutpat. Nunc a lacinia eros. Nullam accumsan rutrum arcu sed varius. Sed bibendum lobortis velit, vel ultricies diam scelerisque sit amet. Phasellus diam metus, ultricies sed cursus porta, ultricies at est. In suscipit venenatis purus, vel blandit est. Duis libero turpis, fringilla vel orci vitae, consectetur suscipit felis. Mauris cursus nisl et ex fringilla dapibus. Etiam iaculis nisi sapien, in pretium odio porttitor ac. Phasellus pulvinar viverra ex, nec eleifend lectus maximus ac."));
            this._items.Add(new Section(2, "Test2", "Test description"));
        }

        public Section FindByName(string name)
        {
            return _items.First<Section>(item => item.Name == name);
        }
    }
}
