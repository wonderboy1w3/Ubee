

using Ubee.Domain.Entities;

namespace Ubee.Data.IRepositories;

public interface ITransactionRepository
{
    ValueTask<Transaction> InsertTransactionAsync(Transaction transaction);
    ValueTask<Transaction> UpdateTransactionAsync(Transaction transaction);
    ValueTask<bool> DeleteTransactionAysnyc(long id);
    ValueTask<Transaction> SelectTransactionById(Predicate<Transaction> predicate);
    IQueryable<Transaction> SelectAllTransactions();
}
