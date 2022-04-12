using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMRB.Data
{
    public class Wallet
    {
        [Key]
        public int WalletId { get; set; }
/*        public Guid ChildId { get; set; }*/

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [ForeignKey(nameof(Transaction))]
        public int? TransactionId { get; set; }
        public virtual Transaction Transaction { get; set; }
        public List<Transaction> Transactions { get; set; } = new List<Transaction>();

        [DisplayName("Date Of Birth")]
        public DateTime BirthDay { get; set; }

        [ForeignKey(nameof(WriteUp))]
        public int? WriteUpId { get; set; }

        public virtual WriteUp WriteUp { get; set; }

    }
}
