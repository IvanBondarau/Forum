using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.Repositories
{
    public interface ICrudRepository<Key, Item>: IDisposable
    {
        Item Create(Item item);
        Item Read(Key key);
        void Update(Item item);
        void Delete(Key key);
        ICollection<Item> FindAll();
    }
}
