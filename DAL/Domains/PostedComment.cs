using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Domains
{
    public class PostedComment : Domain
    {
        public int? BookReadingEventID { get; set; }

        [Required]
        public string Comments {get; set;}

        [Required]
        public string EmailID {get; set;}

        [ForeignKey("BookReadingEventID")]
        public virtual BookReadingEvent BookReadingEvent { get; set; }

    }
}
