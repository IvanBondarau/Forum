using Forum.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.Services.Implementatios
{
    public class AbstractCrudService<Key, Item> : ICrudService<Key, Item>
    {
        private readonly ICrudRepository<Key, Item> repository;

        protected AbstractCrudService(ICrudRepository<Key, Item> repository)
        {
            this.repository = repository;
        }

        public Item Create(Item item)
        {
            return repository.Create(item);
        }

        public Item Read(Key key)
        {
            return repository.Read(key);
        }

        public void Update(Item item)
        {
            repository.Update(item);
        }

        public void Delete(Key key)
        {
            repository.Delete(key);
        }

        public ICollection<Item> FindAll()
        {
            return repository.FindAll();
        }


    }
}
