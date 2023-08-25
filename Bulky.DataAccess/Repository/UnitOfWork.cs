using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bulky.DataAccess.Data;
using Bulky.DataAccess.Repository.IRepository;

namespace Bulky.DataAccess.Repository
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