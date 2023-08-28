using BulkyWeb.Data;
using BulkyWeb.Repository.IRepository;
using BulkyWeb.Models;

namespace BulkyWeb.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private ApplicationDbContext _db;

        public ProductRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Product obj)
        {
            _db.Update(obj);
        }
        public void Save()
        {
            _db.SaveChanges();
        }
    }
}