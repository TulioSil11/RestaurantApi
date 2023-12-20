using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Restaurant.Domain.Models;
using Restaurant.Infra.Data.MapperClass;

namespace Restaurant.Infra.Data.Contexts;

public class RestaurantContext: DbContext
{
    public DbSet<Dish> Dishes { get; set; }
    public IDbContextTransaction _transaction { get; private set; }
    
    public RestaurantContext(DbContextOptions<RestaurantContext> options): base(options)
    {
        if(Database.GetPendingMigrations().Count() > 0) Database.Migrate();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){}
        
    public IDbContextTransaction InitTransaction()
    { 
        if(_transaction == null) _transaction = this.Database.BeginTransaction();
        return _transaction;
    }
    private void RollBack()
    {
        if (_transaction != null) _transaction.Rollback();
    }    

    private void Save()
    {
        try
        {
            ChangeTracker.DetectChanges();
            SaveChanges();
        }
        catch (Exception ex)
        {
            RollBack();
            throw new Exception(ex.Message);
        }
    }
    private void Commit()
    {
        if (_transaction != null)
        {
            _transaction.Commit();
            _transaction.Dispose();
            _transaction = null;
        }
    }

    public void SendChanges()
    {
        Save();
        Commit();
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
            
        modelBuilder.ApplyConfiguration(new DishMap());
    }
}
