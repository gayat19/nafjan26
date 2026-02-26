using ConnectToMongoAPI.Contexts;
using ConnectToMongoAPI.Interfaces;
using ConnectToMongoAPI.Models;
using MongoDB.Driver;

namespace ConnectToMongoAPI.Repositories
{
    public class ProductRepository : IRepository<string, Product>
    {
        private readonly MongoDbContext _context;

        public ProductRepository(MongoDbContext context) 
        { 
            _context = context;
        }
        public async Task<Product> CreateAsync(Product entity)
        {
              await _context.Products.InsertOneAsync(entity);
            return entity;
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return  await _context.Products.Find(_ => true).ToListAsync();
        }

        public async Task<Product> GetByIdAsync(string id)
        {
            return await _context.Products.Find(p => p.Id == id).FirstOrDefaultAsync();
        }
    }
}
