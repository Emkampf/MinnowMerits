using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MMRB.Models
{
    public class TransactionEdit
    {
        public int TransactionId { get; set; }
        public DateTimeOffset DateOfTransaction { get; set; }

        public int eventId { get; set; }
    }
}