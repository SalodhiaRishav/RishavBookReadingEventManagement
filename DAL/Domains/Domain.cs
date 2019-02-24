using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.Interfaces;

namespace DAL.Domains
{
    public class Domain : IDomain
    {
        [Required]
        public int ID { get ; set; }

        [Required]
       // [DataType(DataType.Date)]
        public DateTime CreatedOn { get; set ; }

        [Required]
       // [DataType(DataType.Date)]
        public DateTime ModifiedOn { get; set; }
    }
}
