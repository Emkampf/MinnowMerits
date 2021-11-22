using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MMRB.Models
{
    public class TransactionDetail
    {
        [Display(Name = "Transaction Number")]
        public int TransactionId { get; set; }
        [Display(Name = "Date of Transaction")]
        public DateTimeOffset DateOfTransaction { get; set; }

        public int EventId { get; set; }
    }
}