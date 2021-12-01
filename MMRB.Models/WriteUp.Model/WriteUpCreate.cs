using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MMRB.Models
{
    public class WriteUpCreate
    {
        [Display(Name = "Write Up Number")]
        public int WriteUpId { get; set; }
        [Display(Name = "How Many Write Ups")]
        public int WriteUps { get; set; }

        [Display(Name = "Wallet")]
        public int WalletId { get; set; }
    }
}