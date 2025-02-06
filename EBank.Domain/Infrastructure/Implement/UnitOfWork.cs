using EBank.Domain.Context;
using EBank.Domain.Infrastructure.Define;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBank.Domain.Infrastructure.Implement
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDbFactory _dbFactory;
        private EBankDbContext dbcontext;

        public UnitOfWork(IDbFactory dbFactory)
        {
            this._dbFactory = dbFactory;
        }

        public EBankDbContext DbContext
        {
            get { return dbcontext ?? (dbcontext = _dbFactory.Init()); }
        }


        public void Commit()
        {
            DbContext.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await DbContext.SaveChangesAsync();
        }
    }
}
