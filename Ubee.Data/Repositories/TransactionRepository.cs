using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Ubee.Data.Contexts;
using Ubee.Domain.Entities;
namespace Ubee.Data.Repositories;
public class TransactionRepository
{
    private readonly AppDbContext appDbContext = new AppDbContext();

    public async ValueTask<Transaction> InsertTransactionAsync(Transaction transaction)
    {
        EntityEntry<Transaction> entity = await this.appDbContext.Transactions.AddAsync(transaction);
        await appDbContext.SaveChangesAsync();
        return entity.Entity;
    }

    public async ValueTask<Transaction> UpdateTransactionAsync(Transaction transaction)
    {
        EntityEntry<Transaction> entity = this.appDbContext.Transactions.Update(transaction);
        await appDbContext.SaveChangesAsync();
        return entity.Entity;
    }

    public async ValueTask<bool> DeleteTransactionAysnyc(long id)
    {
        Transaction entity =
        await this.appDbContext.Transactions.FirstOrDefaultAsync(tr => tr.Id.Equals(id));
        if (entity is null)
            return false;

        this.appDbContext.Transactions.Remove(entity);
        await this.appDbContext.SaveChangesAsync();
        return true;
    }

    public async ValueTask<Transaction> SelectTransactionById(Predicate<Transaction> predicate) =>
        await this.appDbContext.Transactions.Where(info => info.IsActive).FirstOrDefaultAsync(tr => predicate(tr));

    public IQueryable<Transaction> SelectAllInfos() =>
        this.appDbContext.Transactions.Where(tr => tr.IsActive);
}
