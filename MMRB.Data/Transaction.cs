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
        public DateTimeOffset CreatedUtc { get; set; }

        public DateTimeOffset? ModifiedUtc { get; set; }
        [ForeignKey(nameof(Event))]
        public int eventId { get; set; }
/*        [ForeignKey(nameof(Wallet))]
        public int FirstName { get; set; }
        [ForeignKey(nameof(Wallet))]
        public int LastName { get; set; }*/

        public enum TransactionType  
        {
            [Display(Name = "Withdraw")]
            WD,
            [Display(Name = "Deposit")]
            D,
        }

    }
}
