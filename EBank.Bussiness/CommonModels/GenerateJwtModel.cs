using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBank.Bussiness.CommonModels
{
    public class GenerateJwtModel
    {
        public Guid Id { get; set; }
        public string BankNumber { get; set; } = string.Empty;
    }
}
