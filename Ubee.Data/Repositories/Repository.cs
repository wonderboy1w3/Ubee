using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq.Expressions;
using Ubee.Data.Contexts;
using Ubee.Data.IRepositories;
using Ubee.Domain.Commons;

namespace Ubee.Data.Repositories;
public class Repository<T> : IRepository<T> where T : Auditable
{
    protected readonly AppDbContext appDbContext;
    protected readonly DbSet<T> dbset;
    public Repository(AppDbContext appDbContext)
    {
        this.appDbContext = appDbContext;
        this.dbset = appDbContext.Set<T>();
    }
    public async ValueTask<bool> DeleteAsync(Expression<Func<T, bool>> expression)
    {
        var entity = await this.SelectAsync(expression);
        if(entity != null)
        {
            entity.IsDeleted = true;
            return true;
        }
        return false;
    }

    public async ValueTask<T> InsertAsync(T entity)
    {
        EntityEntry<T> entry = await this.dbset.AddAsync(entity);
        return entry.Entity;
    }

    public async ValueTask SaveAsync()
    {
        await appDbContext.SaveChangesAsync();
    }

    public IQueryable<T> SelectAllAsync(Expression<Func<T, bool>> expression = null, string[] includes = null)
    {
        IQueryable<T> query = expression is null ? this.dbset : this.dbset.Where(expression);
        if(includes is not null)
        {
            foreach(string include in includes)
            {
                query= query.Include(include);
            }
        }
        return query;
    }

    public async ValueTask<T> SelectAsync(Expression<Func<T, bool>> expression = null, string[] includes = null)
        =>await this.SelectAllAsync(expression, includes).FirstOrDefaultAsync();    

    public T UpdateAsync(T entity)
    {
        EntityEntry<T> entry = this.appDbContext.Update(entity);
        return entry.Entity;
    }
}
