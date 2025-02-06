using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EBank.Domain.Entities;

namespace EBank.Domain.ConfigModel
{
    public class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder.Property(a => a.Amount)
                .HasColumnType("decimal(18, 2)");

            builder.HasOne(o => o.Account)
                .WithMany(c => c.Transactions)
                .HasForeignKey(o => o.AccountId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
