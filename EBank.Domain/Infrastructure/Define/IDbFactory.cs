using EBank.Domain.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBank.Domain.Infrastructure.Define
{
    public interface IDbFactory : IDisposable
    {
        EBankDbContext Init();
    }
}
