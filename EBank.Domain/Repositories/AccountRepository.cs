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
    public interface IAccountRepository : IRepository<Account> { }
    public class AccountRepository : Repository<Account>, IAccountRepository
    {
        public AccountRepository(IDbFactory dbFactory) : base(dbFactory)
        {
            
        }
    }
}
