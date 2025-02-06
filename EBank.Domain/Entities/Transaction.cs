using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBank.Domain.Entities
{
    [Table("Transactions")]
    public class Transaction : BaseEntity
    {
        public decimal Amount { get; set; }
        [StringLength(16)]
        public string BankNumberTo { get; set; } = string.Empty;

        //ForeignKey
        public Guid AccountId { get; set; }
        public Account Account { get; set; }
    }
}
