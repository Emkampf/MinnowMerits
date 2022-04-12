using MMRB.Models.Helper;
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
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTimeOffset CreatedUtc { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTimeOffset? ModifiedUtc { get; set; }

        [ForeignKey(nameof(Event))]
        public int? EventId { get; set; }

        public virtual Event Event { get; set; }

/*        public TransactionType TypeTransaction { get; set; }*/

        [ForeignKey(nameof(Wallet))]
        public int? WalletId { get; set; }

        public virtual Wallet Wallet { get; set; }


    }
}
