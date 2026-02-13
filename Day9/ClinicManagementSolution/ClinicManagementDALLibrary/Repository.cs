using ClinicManagementDALLibrary.Contexts;
using ClinicManagementDALLibrary.Interfaces;

namespace ClinicManagementDALLibrary
{
    public abstract class Repository<K, T> : IRepository<K, T> where T : class
    {
        //protected Dictionary<K,T> _items = new Dictionary<K,T>();
        protected ClinicContext clinicContext = new ClinicContext();
        public  T? Add(T item)
        {
            clinicContext.Add(item);
            clinicContext.SaveChanges();
            return item;
        }
        

        public T? Delete(K key)
        {
           var item = Get(key);
            if (item != null)
            {
                //_items.Remove(key);
                clinicContext.Remove(item);
                clinicContext.SaveChanges();
            }
            return item;
        }

        public abstract T? Get(K key);


        public abstract IEnumerable<T>? GetAll();
        
        public T? Update(K key, T item)
        {
            var existingItem = Get(key);
            if (existingItem != null)
            {
                clinicContext.Update(existingItem);
                clinicContext.SaveChanges();
                return existingItem;
            }
            return null;
        }
    }
}
