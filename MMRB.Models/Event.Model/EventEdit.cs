using MMRB.Models.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MMRB.Models
{
    public class EventEdit
    {
        public int EventId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public TransactionType TransactionType { get; set; }

    }
}