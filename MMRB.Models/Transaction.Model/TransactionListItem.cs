﻿using MMRB.Models.Helper;
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

        [Display(Name = "Created")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTimeOffset CreatedUtc { get; set; }

        [Display(Name = "Modified")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTimeOffset? ModifiedUtc { get; set; }

        [Display(Name = "Event Number")]
        public int EventId { get; set; }
        public TransactionType TypeTransaction { get; set; }

    }
}