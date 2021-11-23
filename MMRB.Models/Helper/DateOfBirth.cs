using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMRB.Models.Helper
{
    public class DateOfBirth
    {
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
