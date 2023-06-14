using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Ubee.Data.Contexts;
using Ubee.Data.IRepositories;
using Ubee.Domain.Entities;

namespace Ubee.Data.Repositories;

public class Repository : IWalletRepository
{
    private readonly AppDbContext appDbContext = new AppDbContext();

    public async ValueTask<Wallet> InsertWalletAsync(Wallet wallet)
    {
        EntityEntry<Wallet> entity = await this.appDbContext.Wallets.AddAsync(wallet);
        await appDbContext.SaveChangesAsync();
        return entity.Entity;
    }

    public async ValueTask<Wallet> UpdateWalletAsync(Wallet wallet)
    {
        EntityEntry<Wallet> entity = this.appDbContext.Wallets.Update(wallet);
        await appDbContext.SaveChangesAsync();
        return entity.Entity;
    }

    public async ValueTask<bool> DeleteWalletAysnyc(long id)
    {
        Wallet entity =
        await this.appDbContext.Wallets.FirstOrDefaultAsync(wallet => wallet.Id.Equals(id));
        if (entity is null)
            return false;

        this.appDbContext.Wallets.Remove(entity);
        await this.appDbContext.SaveChangesAsync();
        return true;
    }

    public async ValueTask<Wallet> SelectWalletAsync(Predicate<Wallet> predicate) =>
        await this.appDbContext.Wallets.Where(wallet => wallet.IsActive).FirstOrDefaultAsync(wallet => predicate(wallet));

    public IQueryable<Wallet> SelectAllWallets() =>
        this.appDbContext.Wallets.Where(wallet => wallet.IsActive);
}
