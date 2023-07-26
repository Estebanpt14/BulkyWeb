using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bulky.DataAccess.Data;
using System.Linq.Expressions;
using Bulky.DataAccess.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Bulky.DataAccess.Repository
{
  public class Repository<T> : IRepository<T> where T : class
  {

    private readonly ApplicationDbContext _db;
    internal DbSet<T> dbSet;

    public Repository(ApplicationDbContext db)
    {
      _db = db;
      this.dbSet = _db.Set<T>();
    }

    public IEnumerable<T> GetAll()
    {
      IQueryable<T> query = dbSet;
      return query.ToList();
    }

    public T GetFirstOrDefault(Expression<Func<T, Boolean>> filter)
    {
      IQueryable<T> query = dbSet;
      query = query.Where(filter);
      return query.FirstOrDefault();
    }

    public void Add(T entity)
    {
      dbSet.Add(entity);
    }

    public void Remove(T entity)
    {
      dbSet.Remove(entity);
    }

    public void RemoveRange(IEnumerable<T> entities)
    {
      dbSet.RemoveRange(entities);
    }
  }
}