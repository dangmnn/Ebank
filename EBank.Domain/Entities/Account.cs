using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBank.Domain.Entities
{
    [Table("Accounts")]
    public class Account : BaseEntity
    {
        [StringLength(16)]
        public required string BankNumber { get; set; } = string.Empty;
        public decimal Balance { get; set; }
        [StringLength(255)]
        public string FullName { get; set; } = string.Empty;
        [StringLength(10)]
        public string Phone { get; set; } = string.Empty;
        public virtual List<Transaction> Transactions { get; set; } = new();
    }
}
