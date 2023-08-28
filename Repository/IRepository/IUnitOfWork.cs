namespace BulkyWeb.Repository.IRepository
{
  public interface IUnitOfWork
  {
    ICategoryRepository CategoryRepository { get; }

    void Save();
  }
}