using FirstAPI.Contexts;
using FirstAPI.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FirstAPI.Repositories
{
    public class Repository<K, T> : IRepository<K, T> where T : class
    {
        protected ClinicContext _context;

        public Repository(ClinicContext context)
        {
            _context = context;
        }
        public async Task<T?> Add(T item)
        {
            _context.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<T> Delete(K key)
        {
            var item = await Get(key);
            if(item != null)
            {
                _context.Remove(item);
                await _context.SaveChangesAsync();
                return item;
            }
            return null;
        }

        public async Task<T?> Get(K key)
        {
            var item = await _context.FindAsync<T>(key);   
            return item != null ? item : null;
        }

        public async Task<IEnumerable<T>?> GetAll()
        {
            var items = await _context.Set<T>().ToListAsync();
            if(items.Any())
                return items;
            return null;
        }

        public async Task<T?> Update(K key, T item)
        {
            var existingItem = await Get(key);
            if(existingItem != null)
            {
                _context.Entry(existingItem).CurrentValues.SetValues(item);
                await _context.SaveChangesAsync();
                return existingItem;
            }
            return null;
        }
    }
}
