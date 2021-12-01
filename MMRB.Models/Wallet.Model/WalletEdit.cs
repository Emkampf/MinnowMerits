using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MMRB.Models
{
    public class WalletEdit
    {
        public int WalletId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime BirthDay { get; set; }
    }
}