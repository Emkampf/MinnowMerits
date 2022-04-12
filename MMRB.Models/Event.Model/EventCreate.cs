using MMRB.Models.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MMRB.Models
{
    public class EventCreate
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        [Display(Name = "Transaction Type")]
        public TransactionType TransactionType { get; set; }

    }
}