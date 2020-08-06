using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.Services
{
    public interface ICrudService<T, U>
    {
        T Create(T item);
        T Read(U key);
        void Update(T item);
        void Delete(U key);
        ICollection<T> FindAll();
    }
}
