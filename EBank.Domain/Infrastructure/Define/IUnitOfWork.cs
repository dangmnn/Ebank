using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBank.Domain.Infrastructure.Define
{
    public interface IUnitOfWork
    {
        void Commit();
        Task CommitAsync();
    }
}
