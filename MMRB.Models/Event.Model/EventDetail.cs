using MMRB.Models.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MMRB.Models
{
    public class EventDetail
    {
        public int EventId { get; set; }
        [Display(Name = "Title")]
        public string Title { get; set; }
        [Display(Name = "Description")]
        public string Description { get; set; }
        [Display(Name = "Price")]
        public decimal Price { get; set; }
        [Display(Name ="Transaction Type")]
        public TransactionType TransactionType { get; set; }

    }
}