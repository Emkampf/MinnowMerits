using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMRB.Data
{
    public class  WriteUp
    {
        [Key]
        public int WriteUpId { get; set; }
        public int WriteUps { get; set; }
    }
}
