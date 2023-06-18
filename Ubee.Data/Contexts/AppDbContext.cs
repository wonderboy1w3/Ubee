using Ubee.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Ubee.Data.Contexts;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {}

    public DbSet<Info> Infos { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Wallet> Wallets { get; set; }
    public DbSet<Currency> Currencies { get; set; }
    public  DbSet<Category> Categories { get; set; }
    public DbSet<Transaction> Transactions { get; set; }
    public DbSet<CategoryDetail> CategoriesDetails { get; set; }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{

        modelBuilder.Entity<User>()
            .HasMany(u => u.Wallets)
            .WithOne(w => w.User)
            .HasForeignKey(w => w.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Currency>()
            .HasMany(c => c.Wallets)
            .WithOne(w => w.Currency)
            .HasForeignKey(w => w.CurrrencyId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Wallet>()
            .HasMany(w => w.Infos)
            .WithOne(I => I.Wallet)
            .HasForeignKey(I => I.WalletId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Wallet>()
            .HasMany(w => w.Transactions)
            .WithOne(t => t.Wallet)
            .HasForeignKey(t => t.WalletId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<CategoryDetail>()
            .HasMany(cd => cd.Transactions)
            .WithOne(t => t.CategoryDetail)
            .HasForeignKey(t => t.CategoryDetailId) 
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Category>()
            .HasMany(c => c.categoryDetails)
            .WithOne(cd => cd.Category)
            .HasForeignKey(cd => cd.CategoryId)
            .OnDelete(DeleteBehavior.Cascade);

	}
}
