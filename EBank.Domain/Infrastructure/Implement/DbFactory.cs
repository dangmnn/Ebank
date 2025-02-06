using EBank.Domain.Context;
using EBank.Domain.Infrastructure.Define;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBank.Domain.Infrastructure.Implement
{
    public class DbFactory : Disposable, IDbFactory
    {
        private EBankDbContext dbContext;
        public EBankDbContext Init()
        {
            return dbContext ??= new EBankDbContext();
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}
