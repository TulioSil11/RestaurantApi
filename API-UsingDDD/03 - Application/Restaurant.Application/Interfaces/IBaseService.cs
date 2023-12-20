using Restaurant.Application.DTOs;
using Restaurant.Domain.Models;

namespace Restaurant.Application.Interfaces;
public interface IBaseService<TEntity, TDTO>
    where TEntity : BaseEntity
    where TDTO : BaseDTO
{
    Guid Insert(TDTO entidade);
    void Delete(Guid id);
    void Delete(TDTO entidade);
    void Update(TDTO entidade);
    TDTO GetById(Guid id);
    IEnumerable<TDTO> GetAll();
}

