using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        public Guid ChildId { get; set; }

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



        [ForeignKey(nameof(Transaction))]
        public int? TransactionId { get; set; }
        public virtual Transaction Transaction { get; set; }
        public List<Transaction> Transactions { get; set; } = new List<Transaction>();

        [DisplayName("Date Of Birth")]

        public static int? BirthDay(DateTime birthDay)
        {
            //return null if the date of birth  
            //greater than the current date  
            if (birthDay > DateTime.Now)
                return null;
            // get the basic number of years  
            int years = DateTime.Now.Year - birthDay.Year;
            // adjust the years against this year's  
            // birthday  
            if (DateTime.Now.Month < birthDay.Month ||
               (DateTime.Now.Month == birthDay.Month &&
                DateTime.Now.Day < birthDay.Day))
            {
                years--;
            }
            // Don't return a negative number  
            // for years alive  
            if (years >= 0)
                return years;
            else
                return 0;
        }
    }
}
