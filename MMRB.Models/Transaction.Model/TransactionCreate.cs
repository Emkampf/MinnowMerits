using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MMRB.Models
{
    public class TransactionCreate
    {
        public int TransactionId { get; set; }

        public DateTimeOffset DateOfTransaction { get; set; }

        public int eventId { get; set; }

/*        public string FirstName { get; set; }
        public string LastName { get; set; }
*/
    }
}