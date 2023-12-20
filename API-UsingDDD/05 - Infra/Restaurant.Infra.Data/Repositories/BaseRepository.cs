using Microsoft.EntityFrameworkCore;
using Restaurant.Domain.Interfaces.Repositories;
using Restaurant.Domain.Models;
using Restaurant.Infra.Data.Contexts;

namespace Restaurant.Infra.Data.Repositories;
public class BaseRepository<TEntity>: IBaseRepository<TEntity> where TEntity : BaseEntity
{
    private readonly RestaurantContext _context;

    public BaseRepository(RestaurantContext contex)
    {
        _context = contex;
    }

    public void Update(TEntity entity)
    {
        _context.InitTransaction();
        _context.Set<TEntity>().Attach(entity);
        _context.Entry(entity).State = EntityState.Modified;
        _context.SendChanges();
    }

    public void Delete(Guid id)
    {
        var entity = GetById(id);
        if(entity != null)
        {
            _context.InitTransaction();
            _context.Set<TEntity>().Remove(entity);
            _context.SendChanges();
        }
    }

    public void Delete(TEntity entity)
    {
        _context.InitTransaction();
        _context.Set<TEntity>().Remove(entity);
        _context.SendChanges();
    }

    public Guid Add(TEntity entity)
    {
        _context.InitTransaction();
        var id = _context.Set<TEntity>().Add(entity).Entity.Id;
        _context.SendChanges();
        return id;
    }

    public TEntity GetById(Guid id)
    {
        return _context.Set<TEntity>().Find(id);
    }

    public IEnumerable<TEntity> GetAll()
    {
        return _context.Set<TEntity>().ToList();
    }
}
