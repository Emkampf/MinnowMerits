using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MMRB.Models
{
    public class TransactionListItem
    {
        [Display(Name = "Transaction Number")]
        public int TransactionId { get; set; }

        [Display(Name = "Date Of Transaction")]
        public DateTimeOffset DateOfTransaction { get; set; }
        [Display(Name = "Event Number")]
        public int eventId { get; set; }

    }
}