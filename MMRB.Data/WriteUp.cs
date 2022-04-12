using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMRB.Data
{
    public class WriteUp
    {
        [Key]
        public int WriteUpId { get; set; }
        public int WriteUps { get; set; }

       [ForeignKey(nameof(Wallet))]
       public int? WalletId { get; set; }
       public virtual Wallet Wallet { get; set; }
       public List<Wallet> Wallets { get; set; } = new List<Wallet>();
    }
}
