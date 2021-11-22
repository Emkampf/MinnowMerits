using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMRB.Models.Helper
{
    public enum TransactionType
    {
        [Display(Name = "Withdraw")]
        W,
        [Display(Name = "Deposit")]
        D,
    }
}
