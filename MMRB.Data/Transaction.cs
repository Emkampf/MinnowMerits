using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMRB.Data
{
    public class Transaction
    {
        [Key]
        public int TransactionId { get; set; }
        [Required]
        public DateTimeOffset DateOfTransaction { get; set; }
        [ForeignKey(nameof(Event))]
        public int eventId { get; set; }
    }
}
