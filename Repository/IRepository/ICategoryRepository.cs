using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BulkyWeb.Models;

namespace BulkyWeb.Repository.IRepository
{
  public interface ICategoryRepository : IRepository<Category>
  {
    void Update(Category obj);
    void Save();
  }
}