using ClinicManagementDALLibrary.Interfaces;

namespace ClinicManagementDALLibrary
{
    public abstract class Repository<K, T> : IRepository<K, T> where T : class
    {
        protected Dictionary<K,T> _items = new Dictionary<K,T>();
        public abstract T? Add(T item);
        

        public T? Delete(K key)
        {
           var item = Get(key);
            if (item != null)
            {
                _items.Remove(key);
            }
            return item;
        }

        public T? Get(K key)
        {
            if(_items.ContainsKey(key))
                return _items[key];
            return null;
        }

        public IEnumerable<T>? GetAll()
        {
           if( _items.Count == 0 || _items == null)
                return null;
            return _items.Values;
        }

        public T? Update(K key, T item)
        {
            var existingItem = Get(key);
            if (existingItem != null)
            {
                _items[key] = item;
                return existingItem;
            }
            return null;
        }
    }
}
