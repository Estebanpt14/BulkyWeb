using BulkyWeb.Data;
using BulkyWeb.Repository.IRepository;

namespace BulkyWeb.Repository
{
  public class UnitOfWork : IUnitOfWork
  {

    private ApplicationDbContext _db;

    public ICategoryRepository CategoryRepository { get; private set; }
    public IProductRepository ProductRepository { get; private set; }

    public UnitOfWork(ApplicationDbContext db)
    {
      _db = db;
      CategoryRepository = new CategoryRepository(db);
      ProductRepository = new ProductRepository(db);
    }

    public void Save()
    {
      _db.SaveChanges();
    }
  }
}