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
        public int TransactionId { get; set; }
        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset? ModifiedUtc { get; set; }

        //Make Pretty or do Helper(separate class)
        public TransactionType TypeTransaction { get; set; }

        public int EventId { get; set; }

/*        public string FirstName { get; set; }
        public string LastName { get; set; }
*/
    }
}