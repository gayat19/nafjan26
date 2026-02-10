using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrManagementApp.Interfaces
{
    public interface IRepository<K, T> where T : class
    {
        T? Get(K key);
        bool Add(T item);
        bool Update(K key, T item);
        bool Delete(K key);
        IEnumerable<T>? GetAll();
    }
}
