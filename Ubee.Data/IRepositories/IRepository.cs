using System.Linq.Expressions;
using Ubee.Domain.Commons;

namespace Ubee.Data.IRepositories;
public interface IRepository<T> where T : Auditable
{
    ValueTask<T> InsertAsync(T entity);
    T UpdateAsync(T entity);
    IQueryable<T> SelectAllAsync(Expression<Func<T,bool>> expression = null,string[] includes = null);
    ValueTask<T> SelectAsync(Expression<Func<T,bool>> expression = null, string[] includes = null);
    ValueTask<bool> DeleteAsync(Expression<Func<T, bool>> expression);
    ValueTask SaveAsync();

}
