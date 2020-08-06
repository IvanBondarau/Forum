using Forum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.Services.Implementatios
{
    public class InMemoryCrudService<T> : ICrudService<T, int> where T : BaseModel
    {
        protected List<T> _items;

        public InMemoryCrudService()
        {
            _items = new List<T>();
        } 

        public T Create(T item)
        {
            _items.Add(item);
            return item;
        }

        public T Read(int id)
        {
            return _items.First<T>(
                (item) => item.Id == id
            );
        }

        public void Update(T updatedItem)
        {
            var oldItem = _items.First<T>(item => item.Id == updatedItem.Id);
            _items.Remove(oldItem);
            _items.Add(updatedItem);
        }

        public void Delete(int id)
        {
            var removedItem = _items.First<T>(item => item.Id == id);
            _items.Remove(removedItem);
        }

        public ICollection<T> FindAll()
        {
            return _items;
        }


    }
}
