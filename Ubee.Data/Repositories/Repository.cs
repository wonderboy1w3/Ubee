using Ubee.Data.Contexts;
using Ubee.Domain.Commons;
using System.Linq.Expressions;
using Ubee.Data.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace Ubee.Data.Repositories;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : Auditable
{
    protected readonly AppDbContext dbContext;
    protected readonly DbSet<TEntity> dbSet;
    public Repository(AppDbContext dbContext)
    {
        this.dbContext = dbContext;
        this.dbSet = dbContext.Set<TEntity>();
    }

    public async ValueTask<TEntity> InsertAsync(TEntity entity)
        => (await this.dbSet.AddAsync(entity)).Entity;
    

    public TEntity UpdateAsync(TEntity entity)
    {
        var entry = this.dbContext.Update(entity);
        return entry.Entity;
    }

    public IQueryable<TEntity> SelectAll(Expression<Func<TEntity, bool>> expression = null, string[] includes = null)
    {
        IQueryable<TEntity> query = expression is null ? this.dbSet : this.dbSet.Where(expression);

        if (includes is not null)
            foreach (string include in includes)
                query = query.Include(include);
            
        return query;
    }

    public async ValueTask<TEntity> SelectAsync(Expression<Func<TEntity, bool>> expression = null, string[] includes = null)
     => await this.SelectAll(expression, includes).FirstOrDefaultAsync(t => !t.IsDeleted);

    public async ValueTask<bool> DeleteAysnyc(Expression<Func<TEntity, bool>> expression)
    {
        var entity = await this.SelectAsync(expression);

        if (entity is null)
            return false;

        entity.IsDeleted = true;
        return true;
    }

    public bool DeleteMany(Expression<Func<TEntity, bool>> expression)
    {
        var entities = this.dbSet.Where(expression);
        if (entities.Any())
        {
            foreach (var entity in entities)
                entity.IsDeleted = true;

            return true;
        }
        return false;
    }

    public async ValueTask SaveAsync()
    {
        await this.dbContext.SaveChangesAsync();
    }
}
