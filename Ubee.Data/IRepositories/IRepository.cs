﻿using Ubee.Domain.Commons;
using System.Linq.Expressions;

namespace Ubee.Data.IRepositories;

public interface IRepository<TEntity> where TEntity : Auditable
{
    ValueTask<TEntity> InsertAsync(TEntity entity);
    TEntity UpdateAsync(TEntity entity);
    bool DeleteMany(Expression<Func<TEntity, bool>> expression);
    ValueTask<bool> DeleteAysnyc(Expression<Func<TEntity,bool>> expression);
    IQueryable<TEntity> SelectAll(Expression<Func<TEntity, bool>> expression = null, string[] includes = null);
    ValueTask<TEntity> SelectAsync(Expression<Func<TEntity, bool>> expression = null, string[] includes = null);
    ValueTask SaveAsync();
}