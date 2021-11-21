using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMRB.Data
{
    public class Wallet
    {
       [Key]
        public int WalletId { get; set; }

        [Required]
        public string FirstName { get; set; }
/*        {
            get => _firstName;
            set
            {
                if (value.Length < 1 || value.Any(x => !char.IsLetter(x)))
                    throw new FormatException("Must be atleast 4 characters long.");
                else
                    _firstName = value;
            }
        }*/

        [Required]
        public string LastName { get; set; }
/*        {
            get => _lastName;
            set
            {
                if (value.Length < 1 || value.Any(x => !char.IsLetter(x)))
                    throw new FormatException("Must be atleast 4 characters long.");
                else
                    _lastName = value;
            }
        }*/
        
        public DateTime BirthDate { get; set; }

        [ForeignKey(nameof(Transaction))]
        public List<Transaction> Transactions { get; set; } = new List<Transaction>();
    }
}
