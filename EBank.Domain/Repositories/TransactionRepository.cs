using EBank.Domain.Entities;
using EBank.Domain.Infrastructure.Define;
using EBank.Domain.Infrastructure.Implement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBank.Domain.Repositories
{
    public interface ITransactionRepository : IRepository<Transaction> { }
    public class TransactionRepository : Repository<Transaction>, ITransactionRepository
    {
        public TransactionRepository(IDbFactory dbFactory) : base (dbFactory)
        {
        }
    }
}
