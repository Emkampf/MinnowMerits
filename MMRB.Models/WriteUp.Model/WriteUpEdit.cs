using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MMRB.Models
{
    public class WriteUpEdit
    {
        public int WriteUpId { get; set; }

        public int WriteUps { get; set; }

        [Display(Name = "Wallet")]
        public int WalletId { get; set; }
    }
}