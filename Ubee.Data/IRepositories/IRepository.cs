using Ubee.Domain.Entities;

namespace Ubee.Data.IRepositories;

public interface IRepository
{
    ValueTask<Wallet> InsertWalletAsync(Wallet wallet);
    ValueTask<Wallet> UpdateWalletAsync(Wallet wallet);
    ValueTask<bool> DeleteWalletAysnyc(long id);
    ValueTask<Wallet> SelectWalletAsync(Predicate<Wallet> wallet);
    IQueryable<Wallet> SelectAllWallets();
}
