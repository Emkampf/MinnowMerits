using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMRB.Data
{
    public class Event
    {
        [Key]
        public int EventId { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public decimal Price { get; set; }

    }
}
