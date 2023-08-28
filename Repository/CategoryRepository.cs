using BulkyWeb.Data;
using BulkyWeb.Repository.IRepository;
using BulkyWeb.Models;

namespace BulkyWeb.Repository
{
  public class CategoryRepository : Repository<Category>, ICategoryRepository
  {

    private ApplicationDbContext _db;

    public CategoryRepository(ApplicationDbContext db) : base(db)
    {
      _db = db;
    }

    public void Update(Category obj)
    {
      _db.Update(obj);
    }
    public void Save()
    {
      _db.SaveChanges();
    }
  }
}