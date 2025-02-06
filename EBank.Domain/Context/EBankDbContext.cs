using EBank.Domain.ConfigModel;
using EBank.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EBank.Domain.Context
{
    public class EBankDbContext : DbContext
    {
        public EBankDbContext()
        {
            ChangeTracker.LazyLoadingEnabled = false;
        }
        public EBankDbContext(DbContextOptions<EBankDbContext> options) : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Transaction> Transactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AccountConfiguration());
            modelBuilder.ApplyConfiguration(new TransactionConfiguration());
        }
    }
}
