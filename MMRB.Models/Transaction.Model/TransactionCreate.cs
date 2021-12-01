using MMRB.Models.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MMRB.Models
{
    public class TransactionCreate
    {
        [Display(Name ="Transaction Number")]
        public int TransactionId { get; set; }

        [Display(Name = "Created")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTimeOffset CreatedUtc { get; set; }

        [Display(Name = "Date of Transaction")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTimeOffset? ModifiedUtc { get; set; }
   /*     public TransactionType TypeTransaction { get; set; }*/
        [Display(Name = " Event")]
        public int EventId { get; set; }
        [Display(Name = " Wallet")]
        public int WalletId { get; set; }
    }
}