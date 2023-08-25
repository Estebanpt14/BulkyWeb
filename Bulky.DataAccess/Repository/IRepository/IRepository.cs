using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Bulky.DataAccess.Repository.IRepository
{
  public interface IRepository<T> where T : class
  {
    IEnumerable<T> GetAll();

    T GetFirstOrDefault(Expression<Func<T, Boolean>> filter);

    void Add(T entity);

    void Remove(T entity);

    void RemoveRange(IEnumerable<T> entities);

  }
}