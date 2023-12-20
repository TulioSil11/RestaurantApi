using Restaurant.Domain.Models;

namespace Restaurant.Domain.Interfaces.Repositories;
public interface IBaseRepository<TEntidade> where TEntidade : BaseEntity
{
    Guid Add(TEntidade entity);
    void Delete(Guid id);
    void Delete(TEntidade entity);
    void Update(TEntidade entity);
    TEntidade GetById(Guid id);
    IEnumerable<TEntidade> GetAll();
}
